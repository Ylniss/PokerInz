using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Cards;
using PokerAPI.Enums;

namespace PokerAPI.Game
{
    public abstract class Game : IGame
    {
        public delegate void GameHandler(object sender);
        public event GameHandler GameEvent;
        public event GameHandler TableUpdateEvent;

        public BettingRule BettingRule { get; }

        public IList<IPlayer> Players { get; }

        public IList<IGameAction> GameActions { get; }

        public Deck PlayingCards { get; }

        public ITable Table { get; private set; }

        public virtual bool IsGameOver
        {
            get
            {
                if(Players != null)
                    return Players.Where(x => x.Chips <= 0).Count() >= Players.Count - 1;
                else
                    throw new NullReferenceException("No players in Game.");
            }
        }

        public int BigBlind { get; }

        public int SmallBlind { get; }

        public Game(IList<IPlayer> players, BettingRule bettingRule, int smallBlind, int bigBlind) : this(players, bettingRule, smallBlind, bigBlind, new StandardDeck())
        {
        }

        public Game(IList<IPlayer> players, BettingRule bettingRule, int smallBlind, int bigBlind, Deck playingCards)
        {
            if (players.Count < 2)
                throw new ArgumentException("More than one player is needed to play a game.");

            Players = players;
            BettingRule = bettingRule;
            SmallBlind = smallBlind;
            BigBlind = bigBlind;
            PlayingCards = playingCards;
            Table = new Table(players.Count);

            TableUpdateEvent += new GameHandler(Table.UpdatePlayersCount);

            foreach(Player player in Players)
                player.OnBetChange += new Player.BetHandler(Table.UpdateBet);
        }

        public IPlayer GetNextPlayer(IPlayer player)
        {
            int currentTablePosition = Players.Where(x => x.TablePosition == player.TablePosition).Select(x => x.TablePosition).First();

            if (currentTablePosition == Players.Count - 1)
                return Players.First();

            return Players[currentTablePosition + 1];
        }

        public IPlayer GetNextActivePlayer(IPlayer player)
        {
            if (!Players.Where(x => x.CanTakeAction).Any())
                return null;

            IPlayer nextPlayer;

            int currentTablePosition = Players.Where(x => x.TablePosition == player.TablePosition).Select(x => x.TablePosition).First();

            if (currentTablePosition == Players.Count - 1)
                nextPlayer = Players.First();
            else
                nextPlayer =  Players[currentTablePosition + 1];

            if (!nextPlayer.CanTakeAction)
                nextPlayer = GetNextActivePlayer(nextPlayer);

            return nextPlayer;
        }

        public void RemoveLostPlayers()
        {
            var lostPlayers = Players.Where(x => x.Chips <= 0).ToArray();

            for (int i = 0; i < lostPlayers.Count(); ++i)
                Players.Remove(lostPlayers.ElementAt(i));

            for (int i = 0; i < Players.Count; ++i)
                Players[i].TablePosition = i;

            if (TableUpdateEvent != null)
                TableUpdateEvent(this);
        }

        public abstract void HandOutCardsToPlayers();

        public abstract void ReturnCardsToDeck();

        public abstract void SetBlinds();

        public void Licitation()
        {
            onDealStart();
            onLicitation();
            onDealFinish();
        }

        protected abstract void onDealStart();

        protected abstract void onLicitation();

        protected abstract void onDealFinish();

        protected virtual void notify()
        {
            if (GameEvent != null)
                GameEvent(this);
        }

        protected int evaluatePlayerHand(IPlayer player)
        {
            foreach (ICard card in player.HoleCards)
                Table.CommunityCards.Add(card);

            Table.CommunityCards.EvaluateRanking();

            foreach (ICard card in player.HoleCards)
                Table.CommunityCards.Remove(card);

            return Table.CommunityCards.HandRankingValue;
        }

        /// <summary>
        /// Takes action of given player and if successful returns true.
        /// In case of error/exception returns false.
        /// </summary>
        protected bool takeAction(IPlayer player)
        {
            IGameAction gameAction;

            try
            {
                gameAction = player.TakeAction(Table);
            }
            catch (Exception)
            {
                return false;
            }

            if (gameAction == null)
                return false;

            return true;
        }

        protected bool allPlayersTookAction()
        {
            return Players.Where(x => x.TookAction).Count() == Players.Count;
        }

        protected bool lastPlayerCalled()
        {
            var activePlayersBets = Players.Where(x => x.CanTakeAction).Select(x => x.Bet);

            bool same = activePlayersBets.Distinct().Count() == 1;

            return same && activePlayersBets.First() != 0 && activePlayersBets.Count() + Players.Where(x => x.PlayerState == PlayerState.AllIn).Count() > 1;
        }

        protected bool allActivePlayersChecked()
        {
            int activePlayersCount = Players.Where(x => x.PlayerState != PlayerState.Folded).Count();
            int checkedPlayersCount = Players.Where(x => x.PlayerState == PlayerState.Checked).Count();

            return activePlayersCount == checkedPlayersCount;
        }

        protected bool isOnePlayerActiveLeft()
        {
            //return Players.Where(x => x.PlayerState == PlayerState.Folded).Count() == Players.Count - 1;
            return Players.Where(x => x.CanTakeAction).Count() == 1;
        }

        protected bool allButOnePlayerFolded()
        {
            return Players.Where(x => x.PlayerState == PlayerState.Folded).Count() == Players.Count - 1;
        }
    }
}

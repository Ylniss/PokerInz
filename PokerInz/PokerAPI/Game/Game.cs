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

        public IList<IPlayer> LostPlayers { get; } = new List<IPlayer>(10);

        public IList<IGameAction> GameActions { get; }

        public Deck PlayingCards { get; }

        public ITable Table { get; private set; }

        public IDictionary<IPlayer, int> PlayerHandScores { get; } = new Dictionary<IPlayer, int>();

        public PlayersStats PlayersStats;

        public virtual bool IsGameOver
        {
            get
            {
                if(Players != null || Players.Count == 0)
                    return Players.Where(x => x.Chips <= 0).Count() >= Players.Count - 1;
                else
                    throw new NullReferenceException("No players in Game.");
            }
        }

        public int BigBlind { get; }

        public int SmallBlind { get; }

        public Game(IList<IPlayer> players, BettingRule bettingRule, int smallBlind, int bigBlind, PlayersStats playersStats) : this(players, bettingRule, smallBlind, bigBlind, playersStats, new StandardDeck())
        {
        }

        public Game(IList<IPlayer> players, BettingRule bettingRule, int smallBlind, int bigBlind, PlayersStats playersStats, Deck playingCards)
        {
            if (players.Count < 2)
                throw new ArgumentException("More than one player is needed to play a game.");

            Players = players;
            BettingRule = bettingRule;
            SmallBlind = smallBlind;
            BigBlind = bigBlind;
            PlayersStats = playersStats;
            PlayingCards = playingCards;
            Table = new Table(players.Count, smallBlind, bigBlind);

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

        public void Licitation()
        {
            onDealStart();
            onLicitation();
            onDealFinish();
        }

        /// <summary>
        /// Gets hand ranking depending on given score.
        /// Score has to be between 1 to 7462.
        /// </summary>
        public HandRanking GetHandRanking(int score)
        {
            if (score < 1 || score > 7462)
                throw new ArgumentException("Score is outside of a range (1-7462).");

            if (score >= 6186 && score <= 7462)
                return HandRanking.HighCard;
            else if (score >= 3326 && score <= 6185)
                return HandRanking.Pair;
            else if (score >= 2468 && score <= 3325)
                return HandRanking.TwoPairs;
            else if (score >= 1610 && score <= 2467)
                return HandRanking.ThreeOfAKind;
            else if (score >= 1600 && score <= 1609)
                return HandRanking.Straight;
            else if (score >= 323 && score <= 1599)
                return HandRanking.Flush;
            else if (score >= 167 && score <= 322)
                return HandRanking.FullHouse;
            else if (score >= 11 && score <= 166)
                return HandRanking.FourOfAKind;
            else if (score >= 2 && score <= 10)
                return HandRanking.StraightFlush;

            return HandRanking.RoyalFlush;
        }

        public HandRanking GetHandRanking(IPlayer player)
        {
            return GetHandRanking(PlayerHandScores[player]);
        }

        public void ResetGame(GameSettings gameSettings)
        {
            int tablePosition = 0;
            foreach (var player in LostPlayers)
            {
                player.Chips = gameSettings.PlayersStartingCash[player];
                player.Reset();
                player.TablePosition = tablePosition++;

                Players.Add(player);
            }

            LostPlayers.Clear();
        }

        protected void removeLostPlayers()
        {
            var lostPlayers = Players.Where(x => x.Chips <= 0).ToArray();

            for (int i = 0; i < lostPlayers.Count(); ++i)
            {
                LostPlayers.Add(lostPlayers.ElementAt(i)); //list of players in order of loosing
                Players.Remove(lostPlayers.ElementAt(i));
            }

            for (int i = 0; i < Players.Count; ++i)
                Players[i].TablePosition = i;

            if (Players.Count == 1) //last player only
            {
                if (PlayersStats.PlayersWinCount.ContainsKey(Players[0]))
                    PlayersStats.PlayersWinCount[Players[0]] += 1;
                else
                    PlayersStats.PlayersWinCount.Add(Players[0], 1);

                LostPlayers.Add(Players.First());
                Players.RemoveAt(0);

                foreach (var lostPlayer in LostPlayers)
                {
                    if(PlayersStats.PlayerPerformanceScores.ContainsKey(lostPlayer))
                        PlayersStats.PlayerPerformanceScores[lostPlayer] += LostPlayers.IndexOf(lostPlayer);
                    else
                        PlayersStats.PlayerPerformanceScores.Add(lostPlayer, LostPlayers.IndexOf(lostPlayer));
                }
            }

            if (TableUpdateEvent != null)
                TableUpdateEvent(this);
        }

        protected abstract void handOutCardsToPlayers();

        protected abstract void returnCardsToDeck();

        protected abstract void setBlinds();

        protected abstract void onDealStart();

        protected abstract void onLicitation();

        protected abstract void onDealFinish();

        protected virtual void notify()
        {
            if (GameEvent != null)
                GameEvent(this);
        }

        /// <summary>
        /// Evaluates player hand using Table evaluator. Sets ranking to a dictionary of player scores.
        /// </summary>
        protected void evaluatePlayerHand(IPlayer player)
        {
            foreach (ICard card in player.HoleCards)
                Table.CommunityCards.Add(card);

            Table.CommunityCards.EvaluateRanking();

            foreach (ICard card in player.HoleCards)
                Table.CommunityCards.Remove(card);

            PlayerHandScores[player] = Table.CommunityCards.HandRankingValue;
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
            var activeAndAllinPlayerBets = Players.Where(x => x.CanTakeAction || x.PlayerState == PlayerState.AllIn).Select(x => x.Bet);

            bool same = activeAndAllinPlayerBets.Distinct().Count() == 1;

            return same && activeAndAllinPlayerBets.First() != 0 && activeAndAllinPlayerBets.Count() + Players.Where(x => x.PlayerState == PlayerState.AllIn).Count() > 1;
        }

        protected bool allActivePlayersChecked()
        {
            int activePlayersCount = Players.Where(x => x.PlayerState != PlayerState.Folded).Count();
            int checkedPlayersCount = Players.Where(x => x.PlayerState == PlayerState.Checked).Count();

            return activePlayersCount == checkedPlayersCount;
        }

        protected bool isOnePlayerActiveLeft()
        {
            return Players.Where(x => x.CanTakeAction).Count() == 1;
        }

        protected bool allButOnePlayerFolded()
        {
            return Players.Where(x => x.PlayerState == PlayerState.Folded).Count() == Players.Count - 1;
        }

        protected bool isBiggerBetToCall()
        {
            var biggestBet = Players.Where(x => x.CanTakeAction || x.PlayerState == PlayerState.AllIn).Select(x => x.Bet).Max();

            var biggestActivePlayerBet = Players.Where(x => x.CanTakeAction).Select(x => x.Bet).Max();

            return biggestBet > biggestActivePlayerBet;
        }
    }
}

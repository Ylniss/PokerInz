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
            Table = new Table(0, players.Count);
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
            if (!Players.Where(x => x.PlayerState == PlayerState.Active).Any())
                throw new InvalidOperationException("There are no active players.");

            IPlayer nextPlayer;

            int currentTablePosition = Players.Where(x => x.TablePosition == player.TablePosition).Select(x => x.TablePosition).First();

            if (currentTablePosition == Players.Count - 1)
                nextPlayer = Players.First();
            else
                nextPlayer =  Players[currentTablePosition + 1];

            if (nextPlayer.PlayerState == PlayerState.Folded)
                nextPlayer = GetNextActivePlayer(nextPlayer);

            return nextPlayer;
        }

        public abstract void HandOutCardsToPlayers();

        public abstract void ReturnCardsToDeck();

        public abstract void SetBlinds();

        public abstract void Licitation();

        public abstract void OnDealFinish();

        protected virtual void notify()
        {
            if (GameEvent != null)
                GameEvent(this);
        }
    }
}

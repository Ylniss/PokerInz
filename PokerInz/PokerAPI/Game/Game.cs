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

        public Game(IList<IPlayer> players, BettingRule bettingRule) : this(players, bettingRule, new StandardDeck())
        {
        }

        public Game(IList<IPlayer> players, BettingRule bettingRule, Deck playingCards)
        {
            if (players.Count < 2)
                throw new ArgumentException("More than one player is needed to play a game.");

            Players = players;
            BettingRule = bettingRule;
            PlayingCards = playingCards;
            Table = new Table(0);
        }

        public abstract void StartDeal();
    }
}

using PokerAPI.Interfaces;
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
        }

        public ITable GetTable()
        {
            if (GameActions.Last() != null)
                return GameActions.Last().Table;
            else
                throw new NullReferenceException("No elements in GameActions.");
        }

        public abstract void StartDeal();
    }
}

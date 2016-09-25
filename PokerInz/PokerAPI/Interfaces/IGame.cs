using PokerAPI.Cards;
using PokerAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public interface IGame
    {
        /// <summary>
        /// All game actions taken by players during a game.
        /// </summary>
        IList<IGameAction> GameActions { get; }

        /// <summary>
        /// Players that are currently in game.
        /// </summary>
        IList<IPlayer> Players { get; }

        /// <summary>
        /// Rule determining how betting can be done.
        /// </summary>
        BettingRule BettingRule { get; }

        /// <summary>
        /// Deck of playing cards used in game.
        /// </summary>
        Deck PlayingCards { get; }
    }
}

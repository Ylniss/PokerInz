using PokerAPI.Enums;
using PokerAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public interface IPlayer
    {
        /// <summary>
        /// Player's name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Position on the game table.
        /// </summary>
        int TablePosition { get; set; }

        /// <summary>
        /// Current chips in game.
        /// </summary>
        int Chips { get; set; }

        /// <summary>
        /// Cash that is currently bet.
        /// </summary>
        int Bet { get; set; }

        /// <summary>
        /// Indicates that in current state it is possible to take action.
        /// </summary>
        bool CanTakeAction { get; }

        bool TookAction { get; }

        /// <summary>
        /// Type of blind that player has (Big, Small or None).
        /// </summary>
        Blind Blind { get; set; }

        /// <summary>
        /// Pair of cards on players hand.
        /// </summary>
        IList<ICard> HoleCards { get; set; }

        /// <summary>
        /// Indicates player's state (active, fold, check, all-in).
        /// </summary>
        PlayerState PlayerState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IGameAction TakeAction(ITable table);

        /// <summary>
        /// Sets bet for big blind and small blind.
        /// </summary>
        void SetBlindBet(int blind);

        /// <summary>
        /// Resets player to initial state
        /// </summary>
        void Reset();
    }
}

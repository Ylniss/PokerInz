using PokerAPI.Enums;
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
        int TablePosition { get; }

        /// <summary>
        /// Current chips in game.
        /// </summary>
        int Chips { get; set; }

        /// <summary>
        /// Cash that is currently bet.
        /// </summary>
        int Bet { get; set; }

        /// <summary>
        /// Type of blind that player has (Big, Small or None).
        /// </summary>
        Blind Blind { get; set; }

        /// <summary>
        /// Pair of cards on players hand.
        /// </summary>
        IList<ICard> HoleCards { get; set; }

        /// <summary>
        /// Indicates if player has folded.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IGameAction TakeAction(ITable table);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public interface IGameAction
    {
        /// <summary>
        /// Current snapshot of table.
        /// </summary>
        ITable Table { get; }

        /// <summary>
        /// Position of player that currently takes action.
        /// </summary>
        int CurrentPlayerPosition { get; }
    }
}

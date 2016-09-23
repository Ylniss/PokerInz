using PokerAPI.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public interface ITable
    {

        int Pot { get; set; }

        int DealerPosition { get; set; }

        IDictionary<string, int> PlayerBets { get; }

        /// <summary>
        /// Cards that are shown on the table during a game.
        /// </summary>
        EvaluableCards CommunityCards { get; set; }
    }
}

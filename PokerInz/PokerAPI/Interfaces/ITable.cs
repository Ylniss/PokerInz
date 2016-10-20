using PokerAPI.Cards;
using PokerAPI.Enums;
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

        /// <summary>
        /// Current stage of betting round.
        /// </summary>
        GameStage GameStage { get; }

        /// <summary>
        /// Bets made by all players during a game.
        /// </summary>
        IDictionary<string, int> PlayerBets { get; set; }

        /// <summary>
        /// Cards that are shown on the table during a game.
        /// </summary>
        EvaluableCards CommunityCards { get; set; }
    }
}

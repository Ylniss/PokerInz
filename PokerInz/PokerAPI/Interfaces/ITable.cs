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

        int SmallBlind { get; }

        int BigBlind { get; }

        int PlayersCount { get; }

        /// <summary>
        /// Current stage of betting round.
        /// </summary>
        GameStage GameStage { get; }

        /// <summary>
        /// Bets made by all players during a game.
        /// </summary>
        IDictionary<string, int> PlayerBets { get; }

        /// <summary>
        /// Chips of all players
        /// </summary>
        IDictionary<string, int> PlayerChips { get; }

        /// <summary>
        /// Cards that are shown on the table during a game.
        /// </summary>
        EvaluableCards CommunityCards { get; set; }

        void UpdateBetAndChips(object subject);

        void UpdatePlayersCount(object subject);
    }
}

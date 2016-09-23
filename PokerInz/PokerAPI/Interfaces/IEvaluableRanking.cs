using PokerAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public interface IEvaluableRanking
    {
        IRankingEvaluator RankingEvaluator { get; set; }

        HandRanking HandRanking { get; }

        int HandRankingValue { get; }

        void EvaluateRanking();
    }
}

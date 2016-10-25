using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Enums;

namespace PokerAPI.Cards
{
    public abstract class EvaluableCards : CardsCollection, IEvaluableRanking
    {
        private int handRankingValue;

        public HandRanking HandRanking { get; }

        public IRankingEvaluator RankingEvaluator { get; set; }

        public int HandRankingValue { get { return handRankingValue; } }

        public EvaluableCards(IRankingEvaluator rankingEvaluator)
        {
            RankingEvaluator = rankingEvaluator;
            EvaluateRanking();
        }

        public void EvaluateRanking()
        {
            handRankingValue = RankingEvaluator.EvaluateRanking(cards);
        }
    }
}

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
        public HandRanking HandRanking { get; }

        public IList<ICard> ArrangedCards { get; }

        public IRankingEvaluator RankingEvaluator { get; set; }

        public int HandRankingValue { get; set; }

        public EvaluableCards()
        {
            ArrangedCards = new List<ICard>();
            EvaluateRanking();
        }

        public void EvaluateRanking()
        {
            HandRankingValue = RankingEvaluator.EvaluateRanking(cards);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public interface IRankingEvaluator
    {
        int EvaluateRanking(IList<ICard> cards);
    }
}

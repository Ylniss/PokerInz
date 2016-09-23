using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Cards
{
    public class CommunityCards : EvaluableCards
    {
        public IList<ICard> GetFlop()
        {
            if (cards.Count < 3)
                throw new InvalidOperationException("There is less than three cards required for Flop");

            return cards.Take(3).ToList();
        }

        public IList<ICard> GetTurn()
        {
            if (cards.Count < 4)
                throw new InvalidOperationException("There is less than four cards required for Turn");

            return cards.Skip(3).Take(1).ToList();
        }

        public IList<ICard> GetRiver()
        {
            if (cards.Count < 5)
                throw new InvalidOperationException("There is less than five cards required for River");

            return cards.Skip(4).Take(1).ToList();
        }
    }
}

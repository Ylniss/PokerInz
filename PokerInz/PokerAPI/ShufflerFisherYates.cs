using PokerAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public class ShufflerFisherYates : IShuffler
    {
        private static Random random = new Random();

        public void Shuffle(IList<ICard> deck)
        {
            for (int i = deck.Count() - 1; i > 0; --i)
            {
                int n = random.Next(i + 1);
                ICard temp = deck[i];
                deck[i] = deck[n];
                deck[n] = temp;
            }
        }
    }
}

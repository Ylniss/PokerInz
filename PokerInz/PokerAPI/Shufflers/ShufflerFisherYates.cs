using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Shufflers
{
    public class ShufflerFisherYates<T> : IShuffler<T>
    {
        private static Random random = new Random();

        public void Shuffle(IList<T> list)
        {
            for (int i = list.Count() - 1; i > 0; --i)
            {
                int n = random.Next(i + 1);

                T temp = list[i];
                list[i] = list[n];
                list[n] = temp;
            }
        }
    }
}

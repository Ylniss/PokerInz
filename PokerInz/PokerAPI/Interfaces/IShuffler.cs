using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public interface IShuffler<T>
    {
        void Shuffle(IList<T> list);
    }
}

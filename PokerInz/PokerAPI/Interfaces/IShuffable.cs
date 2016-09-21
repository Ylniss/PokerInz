using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public interface IShuffable<T>
    {
        /// <summary>
        /// Shuffling algorithm used in shuffle operation.
        /// </summary>
        IShuffler<ICard> Shuffler { get; set; }

        void Shuffle();
    }
}

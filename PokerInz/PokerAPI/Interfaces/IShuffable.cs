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
        IShuffler<T> Shuffler { get; set; }

        /// <summary>
        /// Shuffles collection in a way implemented by Shuffler.
        /// </summary>
        void Shuffle();
    }
}

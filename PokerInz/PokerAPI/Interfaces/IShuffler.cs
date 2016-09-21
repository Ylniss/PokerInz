﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Interfaces
{
    public interface IShuffler
    {
        void Shuffle(IList<ICard> deck);
    }
}

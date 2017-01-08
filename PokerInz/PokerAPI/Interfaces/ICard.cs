using PokerAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public interface ICard
    {
        CardSuit Suit { get; }

        CardRank Rank { get; }

        bool Equals(object obj);

        int GetHashCode();
    }
}

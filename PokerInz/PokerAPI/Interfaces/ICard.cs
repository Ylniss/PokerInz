using PokerAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Interfaces
{
    public interface ICard
    {
        CardColor Color { get; }

        CardSuit Suit { get; }
    }
}

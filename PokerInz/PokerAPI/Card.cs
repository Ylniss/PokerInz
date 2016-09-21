using PokerAPI.Enums;
using PokerAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public class Card : ICard
    {
        public CardColor Color { get; }

        public CardSuit Suit { get; }

        public Card(CardColor color, CardSuit rank)
        {
            Color = color;
            Suit = rank;
        }

        public override string ToString()
        {
            return $"{Suit} {Color}";
        }
    }
}

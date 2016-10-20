using PokerAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Cards
{
    public class Card : ICard
    {
        public CardSuit Suit { get; }

        public CardRank Rank { get; }

        public Card(CardSuit suit, CardRank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"{Rank.ToFriendlyString()}{Suit.ToFriendlyString()}";
        }
    }
}

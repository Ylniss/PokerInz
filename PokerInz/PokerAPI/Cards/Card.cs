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

        public override bool Equals(object obj)
        {
            ICard other = obj as ICard;
            if (other == null)
                return false;
            return other.Suit.Equals(this.Suit) && other.Rank.Equals(this.Rank);
        }

        public override int GetHashCode()
        {
            return Suit.GetHashCode() + Rank.GetHashCode();
        }
    }
}

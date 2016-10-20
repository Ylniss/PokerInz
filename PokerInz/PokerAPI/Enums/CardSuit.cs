using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Enums
{
    public enum CardSuit
    {
        Hearts = 0,
        Diamonds = 1,
        Clubs = 2,
        Spades = 3,
    }

    public static class CardSuitExtensions
    {
        public static string ToFriendlyString(this CardSuit cardSuit)
        {
            switch (cardSuit)
            {
                case CardSuit.Hearts:
                    return "\u2665";
                case CardSuit.Diamonds:
                    return "\u2666";
                case CardSuit.Clubs:
                    return "\u2663";
                case CardSuit.Spades:
                    return "\u2660";
                default:
                    return "";
            }
        }
    }

}

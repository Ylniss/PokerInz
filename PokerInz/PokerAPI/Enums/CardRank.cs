using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Enums
{
    public enum CardRank
    {       
        Two = 0,
        Three = 1,
        Four = 2,
        Five = 3,
        Six = 4,
        Seven = 5,
        Eight = 6,
        Nine = 7,
        Ten = 8,
        Jack = 9,
        Queen = 10,
        King = 11,
        Ace = 12,
    }

    public static class CardRankExtensions
    {
        public static string ToFriendlyString(this CardRank cardRank)
        {
            switch (cardRank)
            {
                case CardRank.Two:
                    return "2";
                case CardRank.Three:
                    return "3";
                case CardRank.Four:
                    return "4";
                case CardRank.Five:
                    return "5";
                case CardRank.Six:
                    return "6";
                case CardRank.Seven:
                    return "7";
                case CardRank.Eight:
                    return "8";
                case CardRank.Nine:
                    return "9";
                case CardRank.Ten:
                    return "10";
                case CardRank.Jack:
                    return "J";
                case CardRank.Queen:
                    return "Q";
                case CardRank.King:
                    return "K";
                case CardRank.Ace:
                    return "A";
                default:
                    return "";
            }
        }
    }
}

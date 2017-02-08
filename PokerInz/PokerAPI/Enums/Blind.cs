using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Enums
{
    public enum Blind
    {
        None = 0,
        Small = 1,
        Big = 2,
    }

    public static class BlindExtensions
    {
        public static string ToFriendlyString(this Blind blind)
        {
            switch (blind)
            {
                case Blind.None:
                    return "";
                case Blind.Small:
                    return "SB";
                case Blind.Big:
                    return "BB";
                default:
                    return "";
            }
        }
    }
}

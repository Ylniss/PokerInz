using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public class ActionInfo
    {
        public bool IsFoldPossible { get; }
        public int BetToCall { get; }
        public int MinRaise { get; }
        public int MaxRaise { get; }

        public ActionInfo(bool isFoldPossible, int betToCall, int minRaise, int maxRaise)
        {
            IsFoldPossible = isFoldPossible;
            BetToCall = betToCall;
            MinRaise = minRaise;
            MaxRaise = maxRaise;
        }
    }
}

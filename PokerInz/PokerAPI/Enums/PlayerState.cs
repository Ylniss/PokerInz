using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Enums
{
    public enum PlayerState
    {
        Active = 0,
        Called = 1,
        Raised = 2,
        Folded = 3,
        Checked = 4,
        AllIn = 5,
    }
}

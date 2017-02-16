using PokerAPI.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Interfaces
{
    public interface IPlayerAi
    {
        IList<Parameter> Parameters { get; }

        int TakeAction(ITable table, ActionInfo actionInfo);
    }
}

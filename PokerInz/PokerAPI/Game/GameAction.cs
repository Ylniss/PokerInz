using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public class GameAction : IGameAction
    {
        public int CurrentPlayerPosition { get; }

        public ITable Table { get; }

        public GameAction(ITable table)
        {
            Table = table;
        }
    }
}

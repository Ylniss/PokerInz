using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public class GameActionCheck : IGameAction
    {
        public int Pot { get; set; }

        public ITable Table { get; }

        public int CurrentPlayerPosition { get; }
    }
}

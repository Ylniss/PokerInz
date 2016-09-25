using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Cards;

namespace PokerAPI.Game
{
    public class Table : ITable
    {
        public EvaluableCards CommunityCards { get; set; }

        public int DealerPosition { get; set; }

        public IDictionary<string, int> PlayerBets { get; set; }

        public int Pot { get; set; }
    }
}

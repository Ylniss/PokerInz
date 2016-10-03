using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Cards;
using PokerAPI.Enums;

namespace PokerAPI.Game
{
    public class Table : ITable
    {
        public EvaluableCards CommunityCards { get; set; }

        public int DealerPosition { get; set; }

        public GameStage GameStage
        {
            get
            {
                switch(CommunityCards.Count)
                {
                    case 0:
                        return GameStage.Preflop;
                    case 3:
                        return GameStage.Flop;
                    case 4:
                        return GameStage.Turn;
                    case 5:
                        return GameStage.River;
                    default:
                        throw new InvalidOperationException("Unknown game stage to number of community cards.");
                }
            }
        }

        public IDictionary<int, int> PlayerBets { get; set; }

        public int Pot { get; set; }

        public Table(int dealerPosition)
        {
            DealerPosition = dealerPosition;
        }
    }
}

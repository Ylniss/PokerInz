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
        private int playersCount;

        private int dealerPosition;

        public EvaluableCards CommunityCards { get; set; } = new CommunityCards(new MyRankingEvaluator());

        public int DealerPosition
        {
            get
            {
                return dealerPosition;
            }
            set
            {
                if (value < playersCount)
                    dealerPosition = value;
                else
                    dealerPosition = 0;
            }
        }

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

        public IDictionary<string, int> PlayerBets { get; set; } = new Dictionary<string, int>();

        public int Pot { get; set; }

        public Table(int dealerPosition, int playersCount)
        {
            this.dealerPosition = dealerPosition;
            this.playersCount = playersCount;
        }

        public void UpdateBet(object subject)
        {
            if (subject is Player)
            {
                var player = subject as Player;
                PlayerBets[player.Name] = player.Bet;
            }
        }
    }
}

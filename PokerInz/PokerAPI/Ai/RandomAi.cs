using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Enums;
using PokerAPI.Game;

namespace PokerAPI.Ai
{
    public class RandomAi : Player
    {
        private Random random = new Random();

        private float minRiskFactor;
        private float maxRiskFactor;

        public RandomAi(string name, int tablePosition, int chips, float minRiskFactor, float maxRiskFactor) : base(name, tablePosition, chips)
        {
            this.minRiskFactor = minRiskFactor;
            this.maxRiskFactor = maxRiskFactor;
        }

        public override IGameAction TakeAction(ITable table)
        {
            IGameAction gameAction = null;

            int myBet = table.PlayerBets[Name];

            int minimalBet = 0;

            bool isBiggerBet = false;

            if (table.GameStage == GameStage.Flop)
                minimalBet = table.BigBlind;

            if (table.GameStage == GameStage.Turn || table.GameStage == GameStage.River)
                minimalBet = 2 * table.BigBlind;

            int biggestBet = table.PlayerBets.Values.Max();

            if(biggestBet > myBet)
                isBiggerBet = true;

            int choice = random.Next(3); //possibilities: call, raise, fold
            if (!isBiggerBet)
                choice = random.Next(2); //posssibilities: check, raise

            if (isBiggerBet)
            {
                if (biggestBet > Chips * maxRiskFactor)
                    choice = 2;

                if (biggestBet < Chips * minRiskFactor)
                    choice = 1;

                if (choice == 0) //call
                {  
                    gameAction = new GameActionBet(this, table, biggestBet);
                }
                if (choice == 1) //raise
                {
                    int raiseBet = biggestBet + minimalBet + (int)(Chips * minRiskFactor) + random.Next((int)(Chips * maxRiskFactor));
                    if (raiseBet > Chips)
                        raiseBet = Chips;
                    gameAction = new GameActionBet(this, table, raiseBet);
                }
                if (choice == 2) //fold
                {
                    gameAction = new GameActionFold(this, table);
                }
            }
            else
            {
                if (choice == 0) //check
                {
                    gameAction = new GameActionCheck(this, table);
                }
                if (choice == 1) //raise
                {
                    int raiseBet = 0;
                    if (biggestBet == 0)
                        raiseBet = minimalBet + random.Next((int)(Chips * maxRiskFactor));
                    else
                        raiseBet = biggestBet + minimalBet + (int)(Chips * minRiskFactor) + random.Next((int)(Chips * maxRiskFactor));

                    if (raiseBet > Chips)
                        raiseBet = Chips;
                    gameAction = new GameActionBet(this, table, raiseBet);
                }
            }

            return gameAction;
        }
    }
}

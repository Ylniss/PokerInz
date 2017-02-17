using PokerAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Game;

namespace PokerAPI.Ai
{
    public class TestAi : PlayerAi
    {
        private Random random = new Random();

        private float minRiskFactor;
        private float maxRiskFactor;

        public TestAi()
        {
            parameters.Add(new Parameter("minRiskFactor", 0.00f, 0.01f, 0.00f, 1.00f));
            parameters.Add(new Parameter("maxRiskFactor", 1.00f, 0.01f, 0.00f, 1.00f));
        }

        public override int MakeDecision(ITable table, ActionInfo actionInfo)
        {
            int minBet = (int)((ChipsAndBet) * minRiskFactor);
            int maxBet = (int)((ChipsAndBet) * maxRiskFactor); //min and max raise counted for this AI

            int biggestBet = table.PlayerBets.Values.Max();

            if (minBet > ChipsAndBet)
                return ChipsAndBet;

            bool isBiggerBet = false;

            if (biggestBet > CurrentBet)
                isBiggerBet = true;

            int choice = random.Next(3); //fold, call, raise

            if (actionInfo.IsFoldPossible)
            {
                if (isBiggerBet)
                {
                    if (biggestBet > maxBet)
                        choice = 0;

                    if (biggestBet < minBet)
                        choice = 2;
                }

                if (choice == 0) //fold
                    return -1;
                else if (choice == 1) //call
                    return actionInfo.BetToCall;
                else //raise
                    return getRaiseBet(actionInfo, minBet, maxBet, biggestBet);
            }
            else
            {
                choice = random.Next(2); //check, raise

                if (choice == 0) //check
                    return CurrentBet;
                else //raise
                    return getRaiseBet(actionInfo, minBet, maxBet, biggestBet);
            }
        }

        private int getRaiseBet(ActionInfo actionInfo, int minBet, int maxBet, int bb) //bb wywalic
        {
            if (actionInfo.MinRaise == actionInfo.MaxRaise)
            {
                if (ChipsAndBet < actionInfo.MaxRaise)
                {
                    if (ChipsAndBet <= actionInfo.BetToCall || actionInfo.BetToCall == 0)
                        return ChipsAndBet;
                    else
                        return actionInfo.BetToCall;
                } 

                return actionInfo.MaxRaise;
            }
                
            int raiseBet;

            if (actionInfo.MinRaise > minBet)
                minBet = actionInfo.MinRaise;

            if (minBet > maxBet)
                maxBet = minBet;

            if (actionInfo.MaxRaise < maxBet)
            {
                if (minBet > actionInfo.MaxRaise)
                    return actionInfo.MaxRaise;

                raiseBet = random.Next(minBet, actionInfo.MaxRaise);
            }
            else
                raiseBet = random.Next(minBet, maxBet);

            return raiseBet;
        }

        public override void UpdateParams()
        {
            minRiskFactor = parameters[0].Value;
            maxRiskFactor = parameters[1].Value;
        }
    }
}

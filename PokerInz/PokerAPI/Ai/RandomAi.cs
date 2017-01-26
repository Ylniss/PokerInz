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

        public RandomAi(string name, int tablePosition, int chips) : base(name, tablePosition, chips)
        {
        }

        public override IGameAction TakeAction(ITable table)
        {
            IGameAction gameAction = null;

            int myBet = table.PlayerBets[Name];

            bool isBiggerBet = false;

            //foreach (var bet in table.PlayerBets)
            //{
            //    if (bet.Key != Name && bet.Value > myBet)
            //    {
            //        isBiggerBet = true;
            //    }
            //}

            int biggestBet = table.PlayerBets.Values.Max();

            if(biggestBet > myBet)
                isBiggerBet = true;

            int choice = random.Next(3); //possibilities: call, raise, fold
            if (!isBiggerBet)
                choice = random.Next(2); //posssibilities: check, raise

            if (isBiggerBet)
            {
                if (choice == 0) //call
                {
                    gameAction = new GameActionBet(this, table, biggestBet);
                }
                else if (choice == 1) //raise
                {
                    int raiseBet = biggestBet + random.Next(Chips / 2);
                    gameAction = new GameActionBet(this, table, raiseBet);
                }
                else if (choice == 2)
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
                else if (choice == 1) //raise
                {
                    int raiseBet = biggestBet + random.Next(Chips / 2);
                    gameAction = new GameActionBet(this, table, raiseBet);
                }
                else if (choice == 2)
                {
                    gameAction = new GameActionFold(this, table);
                }
            }

            return gameAction;
        }
    }
}

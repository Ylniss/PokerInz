using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public class HumanConsolePlayer : Player
    {
        public HumanConsolePlayer(string name, int tablePosition, int chips) : base(name, tablePosition, chips)
        {
        }

        public override IGameAction TakeAction(ITable table)
        {
            IGameAction gameAction;

            string input = Console.ReadLine();

            input = input.ToLower();

            switch(input[0])
            {
                case 'f':
                    gameAction = new GameActionFold(this);
                    break;
                case 'b':
                    gameAction = new GameActionBet(this, int.Parse(input.Substring(1)));
                    break;
                case 'c':
                    gameAction = new GameActionCheck();
                    break;
                default:
                    throw new ArgumentException($"Wrong input: {input[0]} is not supported.");

            }

            return gameAction;
        }
    }
}

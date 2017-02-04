using PokerAPI;
using PokerAPI.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    public class HumanConsolePlayer : Player
    {
        public HumanConsolePlayer(string name, int tablePosition, int chips) : base(name, tablePosition, chips)
        {
        }

        public override IGameAction TakeAction(ITable table)
        {
            IGameAction gameAction;
            Console.WriteLine($"------------{Name}------------");
            Console.WriteLine($"hole cards: {HoleCards[0]}, {HoleCards[1]}");

            Console.WriteLine("c - check \t b{chips} - bet \t f - fold");
            Console.Write("Input: ");
            string input = Console.ReadLine();

            input = input.ToLower();

            switch(input[0])
            {
                case 'f':
                    gameAction = new GameActionFold(this, table);
                    Console.WriteLine($"{Name} folds.");
                    break;
                case 'b':
                    gameAction = new GameActionBet(this, table, int.Parse(input.Substring(1)));

                    var playerBets = gameAction.Table.PlayerBets;

                    int bet = (gameAction as GameActionBet).Bet;
                    int previousBiggestBet = playerBets.OrderBy(x => x.Value).Skip(playerBets.Count - 2).First().Value;

                    if (previousBiggestBet == bet)
                        Console.WriteLine($"{Name} calls.");
                    else if (previousBiggestBet < bet)
                        Console.WriteLine($"{Name} raises to {bet}.");

                    break;
                case 'c':
                    gameAction = new GameActionCheck(this, table);
                    Console.WriteLine($"{Name} checks.");
                    break;
                default:
                    throw new ArgumentException($"Wrong input: {input[0]} is not supported.");
            }

            string dashes = "";
            foreach (char c in Name)
                dashes += '-';
            Console.WriteLine($"------------{dashes}------------\n");

            return gameAction;
        }
    }
}

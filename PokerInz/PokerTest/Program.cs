using PokerAPI.Cards;
using PokerAPI.Game;
using PokerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Enums;

namespace PokerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new TexasHoldem(new List<IPlayer> {
                new HumanConsolePlayer("p1", 0, 1000),
                new HumanConsolePlayer("p2", 1, 1000),
                new HumanConsolePlayer("p3", 2, 1000),
                new HumanConsolePlayer("p4", 3, 1000),
            }, BettingRule.NoLimit);

            Random random = new Random();

            while (!game.IsGameOver)
            { 
                game.StartDeal();

                foreach (IPlayer player in game.Players)
                    player.Chips -= random.Next(0, 200);

                foreach (IPlayer player in game.Players)
                    Console.WriteLine($"{player.Name} \n {player.HoleCards[0].ToString()}, {player.HoleCards[1].ToString()}\n {player.Chips} \n\n");
            }


            Console.ReadKey();
        }
    }
}

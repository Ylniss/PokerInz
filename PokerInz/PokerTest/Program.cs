using PokerAPI.Cards;
using PokerAPI.Game;
using PokerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Enums;
using PokerAPI.Ai;

namespace PokerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game game = new TexasHoldem(new List<IPlayer> {
            //    new HumanConsolePlayer("bagn000", 0, 1000),
            //    new HumanConsolePlayer("sdfsdf111", 1, 1000),
            //    new HumanConsolePlayer("zrd222", 2, 1000),
            //    new HumanConsolePlayer("pepe333", 3, 1000),
            //}, BettingRule.NoLimit, 10, 20);

            Game game = new TexasHoldem(new List<IPlayer> {
                new HumanConsolePlayer("bagn000", 0, 1000),
                new RandomAi("sdfsdf111", 1, 1000),
                new RandomAi("zrd222", 2, 1000),
                new RandomAi("pepe333", 3, 1000),
            }, BettingRule.NoLimit, 10, 20);

            game.GameEvent += new Game.GameHandler(UpdateGui);

            while (!game.IsGameOver)
            {
                game.Licitation();

                foreach (var hand in game.PlayerHandScores)
                {
                    Console.WriteLine($"{hand.Key.Name}'s ranking: {hand.Value} ({game.GetHandRanking(hand.Value)})");
                }
            }

            Console.WriteLine("\n-------- GAME OVER --------\n");
            Console.WriteLine($"{game.Players.First().Name} wins.");
            Console.ReadKey();
        }

        public static void UpdateGui(object subject)
        {
            if (subject is Game)
            {
                Game game = subject as Game;
                string communityCardsMessage = "Community cards:  ";
                foreach (ICard card in game.Table.CommunityCards)
                    communityCardsMessage += $"{card.ToString()}, ";

                if(communityCardsMessage.Length > 2) //remove last comma
                    communityCardsMessage = communityCardsMessage.Remove(communityCardsMessage.Length - 2);

                Console.WriteLine($"{communityCardsMessage}\n");
                Console.WriteLine("Bets:");
                foreach(IPlayer player in game.Players)
                {
                    string betsMessage = $"{player.Name}  \t chips:\t {player.Chips}\t bet:{player.Bet}";

                    if (player.PlayerState == PlayerState.Active)
                        betsMessage += " [ACTIVE]";
                    else if (player.PlayerState == PlayerState.Folded)
                        betsMessage += " [FOLDED]";
                    else if (player.PlayerState == PlayerState.Checked)
                        betsMessage += " [CHECKED]";
                    else
                        betsMessage += " [ALL-IN]";

                    Console.WriteLine(betsMessage);
                }

                Console.WriteLine($"Pot: {game.Table.Pot}");
            
            }
        }
    }
}

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
                new HumanConsolePlayer("bagn0", 0, 1000),
                new HumanConsolePlayer("sdfsdf1", 1, 1000),
                new HumanConsolePlayer("zrd2", 2, 1000),
                new HumanConsolePlayer("pepe3", 3, 1000),
            }, BettingRule.NoLimit, 10, 20);

            game.GameEvent += new Game.GameHandler(UpdateGui);

            Random random = new Random();

            while (!game.IsGameOver)
            {
                game.PlayingCards.Shuffle();

                game.HandOutCardsToPlayers();

                game.SetBlinds();

                game.Licitation();

                game.ReturnCardsToDeck();

                game.OnDealFinish();
            }

            Console.ReadKey();
        }

        public static void UpdateGui(object subject)
        {
            if (subject is Game)
            {
                Game game = subject as Game;
                string communityCardsMessage = "Community cards: ";
                foreach (ICard card in game.Table.CommunityCards)
                    communityCardsMessage += $"{card.ToString()}, ";

                if(communityCardsMessage.Length > 2) //remove last comma
                    communityCardsMessage = communityCardsMessage.Remove(communityCardsMessage.Length - 2);

                Console.WriteLine($"{communityCardsMessage}\n");
                Console.WriteLine("Bets:");
                foreach(IPlayer player in game.Players)
                {
                    string betsMessage = $"{player.Name} chips: {player.Chips} \t bet:{player.Bet}";
                    if (player.IsActive)
                        betsMessage += " [ACTIVE]";
                    else
                        betsMessage += " [FOLDED]";

                    Console.WriteLine(betsMessage);
                }

                Console.WriteLine($"Pot: {game.Table.Pot}");
            
            }
        }
    }
}

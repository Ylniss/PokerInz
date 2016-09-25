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
            Deck deck = new StandardDeck();

            foreach (var card in deck)
            {
                Console.WriteLine(card.ToString());
            }

            deck.Shuffle();

            Console.WriteLine();

            foreach (var card in deck)
            {
                Console.WriteLine(card.ToString());
            }

            Game game = new TexasHoldem(new List<IPlayer> {
                new Player("p1", 0, 1000),
                new Player("p2", 1, 1000),
                new Player("p3", 2, 1000),
                new Player("p4", 3, 1000),
            }, BettingRule.NoLimit);

            game.StartDeal();



            Console.ReadKey();
        }
    }
}

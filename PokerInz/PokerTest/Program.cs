using PokerAPI.Cards;
using PokerAPI.Game;
using PokerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            ITable table = new Table();

            Console.ReadKey();
        }
    }
}

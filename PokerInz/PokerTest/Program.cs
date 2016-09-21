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
            IDeck deck = new Deck();

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

            Console.ReadKey();
        }
    }
}

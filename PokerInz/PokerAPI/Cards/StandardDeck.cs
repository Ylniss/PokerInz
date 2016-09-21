using PokerAPI.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Cards
{
    public class StandardDeck : Deck
    {
        public StandardDeck() : base()
        {
            cards = getFiftyTwoCardsStandardDeck();
        }

        public StandardDeck(IShuffler<ICard> shuffler) : base(shuffler)
        {
            cards = getFiftyTwoCardsStandardDeck();
        }

        private IList<ICard> getFiftyTwoCardsStandardDeck()
        {
            IList<ICard> cards = new List<ICard>();

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }

            return cards;
        }
    }
}

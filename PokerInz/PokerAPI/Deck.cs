using PokerAPI.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI
{
    public class Deck : IDeck
    {
        public IShuffler<ICard> Shuffler { get; set; }

        private readonly IList<ICard> cards = new List<ICard>();

        public Deck()
        {
            Shuffler = new ShufflerFisherYates();
            cards = getFiftyTwoCardsStandardDeck();
        }

        public Deck(IShuffler<ICard> shuffler)
        {
            Shuffler = shuffler;
            cards = getFiftyTwoCardsStandardDeck();
        }

        public void Shuffle()
        {
            Shuffler.Shuffle(cards);
        }

        public ICard this[int index]
        {
            get
            {
                return cards[index];
            }

            set
            {
                cards[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return cards.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return cards.IsReadOnly;
            }
        }

        public void Add(ICard item)
        {
            cards.Add(item);
        }

        public void Clear()
        {
            cards.Clear();
        }

        public bool Contains(ICard item)
        {
            return cards.Contains(item);
        }

        public void CopyTo(ICard[] array, int arrayIndex)
        {
            cards.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ICard> GetEnumerator()
        {
            return cards.GetEnumerator();
        }

        public int IndexOf(ICard item)
        {
            return cards.IndexOf(item);
        }

        public void Insert(int index, ICard item)
        {
            cards.Insert(index, item);
        }

        public bool Remove(ICard item)
        {
            return cards.Remove(item);
        }

        public void RemoveAt(int index)
        {
            cards.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

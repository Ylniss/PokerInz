using PokerAPI.Enums;
using PokerAPI.Interfaces;
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
        private readonly IList<ICard> cards = new List<ICard>();

        private IShuffler shuffler = new ShufflerFisherYates();

        public Deck()
        {
            cards = getFiftyTwoCardsStandardDeck();
        }

        public void Shuffle()
        {
            shuffler.Shuffle(cards);
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

            foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardSuit rank in Enum.GetValues(typeof(CardSuit)))
                {
                    cards.Add(new Card(color, rank));
                }
            }

            return cards;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Cards
{
    public abstract class Deck : CardsCollection, IShuffable<ICard>
    {
        public IShuffler<ICard> Shuffler { get; set; }

        public Deck()
        {
            Shuffler = new ShufflerFisherYates<ICard>();
        }

        public Deck(IShuffler<ICard> shuffler)
        {
            Shuffler = shuffler;
        }

        public void Shuffle()
        {
            Shuffler.Shuffle(cards);
        }
    }
}

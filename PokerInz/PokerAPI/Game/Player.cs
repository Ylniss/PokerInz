using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Enums;

namespace PokerAPI.Game
{
    public abstract class Player : IPlayer
    {
        public virtual string Name { get; }

        public int Bet { get; set; }

        public Blind Blind { get; set; }

        public int Chips { get; set; }

        public IList<ICard> HoleCards { get; set; }

        public bool IsActive { get; set; }

        public int TablePosition { get; }

        public Player(string name, int tablePosition, int chips)
        {
            Name = name;
            TablePosition = tablePosition;
            Chips = chips;
            IsActive = true;
        }

        public abstract IGameAction TakeAction(ITable table);
    }
}

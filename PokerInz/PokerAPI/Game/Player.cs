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

        private int bet;

        private PlayerState playerState;

        public int Bet
        {
            get { return bet; }
            set
            {
                Chips -= value - bet;
                bet = value;               
            }
        }

        public Blind Blind { get; set; }

        public int Chips { get; set; }

        public IList<ICard> HoleCards { get; set; }

        public PlayerState PlayerState
        {
            get
            {
                if (Chips == 0)
                    return PlayerState.AllIn;
                return playerState;
            }

            set { playerState = value; }
        }

        public int TablePosition { get; }

        public Player(string name, int tablePosition, int chips)
        {
            Name = name;
            TablePosition = tablePosition;
            Chips = chips;
            playerState = PlayerState.Active;
        }

        public abstract IGameAction TakeAction(ITable table);
    }
}

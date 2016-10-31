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

        public delegate void BetHandler(object sender);
        public event BetHandler OnBetChange;

        private int bet;

        private int chips;

        private bool tookAction;

        private PlayerState playerState;

        public int Bet
        {
            get { return bet; }
            set
            {
                if (value != 0)
                {
                    tookAction = true;
                    chips -= value - bet;
                }
                bet = value;
                if (OnBetChange != null)
                    OnBetChange(this);
            }
        }

        public Blind Blind { get; set; }

        public int Chips
        {
            get { return chips; }
            set { chips = value; }
        }

        public IList<ICard> HoleCards { get; set; }

        public PlayerState PlayerState
        {
            get
            {
                if (chips == 0)
                    playerState = PlayerState.AllIn;
                return playerState;
            }

            set
            {
                playerState = value;
                if (value != PlayerState.Active)
                    tookAction = true;
                else
                    tookAction = false;
            }
        }

        public int TablePosition { get; set; }

        public bool CanTakeAction
        {
            get
            {
                if (PlayerState == PlayerState.Active || PlayerState == PlayerState.Checked)
                    return true;
                else
                    return false;
            }
        }

        public bool TookAction { get { return tookAction; } }

        public Player(string name, int tablePosition, int chips)
        {
            Name = name;
            TablePosition = tablePosition;
            this.chips = chips;
            PlayerState = PlayerState.Active;
        }

        public void SetBlindBet(int blind)
        {
            Bet = blind;
            tookAction = false;
        }

        public abstract IGameAction TakeAction(ITable table);
    }
}

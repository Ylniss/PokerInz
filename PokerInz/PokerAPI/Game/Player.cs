using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Enums;
using PokerAPI.Interfaces;

namespace PokerAPI.Game
{
    public class Player : IPlayer
    {
        public virtual string Name { get; }

        public delegate void BetHandler(object sender);
        public event BetHandler UpdateBetAndChips;

        private int bet;

        private int chips;

        private bool tookAction;

        private PlayerState playerState;

        private PlayerAi playerAi;

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
                if (UpdateBetAndChips != null)
                    UpdateBetAndChips(this);
            }
        }

        public Blind Blind { get; set; }

        public int Chips
        {
            get { return chips; }
            set
            {
                chips = value;
                if (UpdateBetAndChips != null)
                    UpdateBetAndChips(this);
            }
        }

        public IList<ICard> HoleCards { get; set; }

        public PlayerState PlayerState
        {
            get
            {
                if (chips == 0)
                    PlayerState = PlayerState.AllIn;

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
                return PlayerState != PlayerState.Folded && PlayerState != PlayerState.AllIn;
            }
        }

        public bool TookAction { get { return tookAction; } }

        public Player(string name, int tablePosition, int chips, PlayerAi playerAi)
        {
            Name = name;
            TablePosition = tablePosition;
            this.chips = chips;
            this.playerAi = playerAi;
            PlayerState = PlayerState.Active;
        }

        public void SetBlindBet(int blind)
        {
            if (blind > Chips)
            {
                Bet = Chips;
                tookAction = true;
            }
            else
            {
                Bet = blind;
                tookAction = false;
            }
        }

        public IGameAction TakeAction(ITable table)
        {
            playerAi.HoleCards = new List<ICard> { HoleCards[0], HoleCards[1] };
            playerAi.Chips = Chips;
            playerAi.CurrentBet = Bet;
            playerAi.TablePosition = TablePosition;

            int biggestBet = table.PlayerBets.Values.Max();
            int biggestChips = table.PlayerChips.Where(x => x.Key != Name).Select(x => x.Value).Max();

            bool isFoldPossible = true;
            int betToCall = biggestBet;
            int minRaise;
            int maxRaise = Chips + Bet;

            if (maxRaise > biggestChips)
                maxRaise = biggestChips;

            if (table.GameStage == GameStage.Preflop || table.GameStage == GameStage.Flop)
                minRaise = biggestBet + table.BigBlind;
            else
                minRaise = biggestBet + 2 * table.BigBlind;

            if (biggestBet == Bet)
            {
                isFoldPossible = false;
                betToCall = 0;
            }

            if (minRaise >= maxRaise)
                maxRaise = minRaise;

            if (betToCall > Chips + Bet)
                betToCall = -1;

            ActionInfo actionInfo = new ActionInfo(isFoldPossible, betToCall, minRaise, maxRaise);

            int choice = playerAi.TakeAction(table, actionInfo);

            if (!isFoldPossible && choice == -1)
                throw new InvalidOperationException("Fold is impossible right now for this player.");

            if(choice > maxRaise)
                throw new InvalidOperationException("Cannot raise more than maximum possible.");

            if(choice < minRaise && betToCall != 0 && betToCall != choice && choice != -1)
                throw new InvalidOperationException("Cannot raise less than minimum possible.");

            if (choice < -1)
                throw new InvalidOperationException($"Invalid bet. Choice {choice} is less than -1.");

            if (choice == -1)
                return new GameActionFold(this, table);
            else if (choice == Bet)
                return new GameActionCheck(this, table);
            else
                return new GameActionBet(this, table, choice);
        }

        public void Reset()
        {
            Bet = 0;
            PlayerState = PlayerState.Active;
        }
    }
}
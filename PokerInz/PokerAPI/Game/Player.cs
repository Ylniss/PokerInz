using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerAPI.Enums;

namespace PokerAPI.Game
{
    class Player : IPlayer
    {
        public string Name { get; }

        public int Bet { get; set; }

        public Blind Blind { get; set; }

        public int Chips { get; set; }

        public Tuple<ICard> HoleCards { get; set; }

        public bool IsActive { get; set; }

        public int TablePosition { get; }

        public Player(string name, int tablePosition, int chips)
        {
            Name = name;
            TablePosition = tablePosition;
            Chips = chips;
            IsActive = true;
        }

        public IGameAction TakeAction(ActionType actionType, IDictionary<string, int> bets, int? bet = null)
        {
            switch (actionType)
            {
                case ActionType.Fold:
                    return new GameActionFold(this);
                case ActionType.Check:
                    return new GameActionCheck();
                case ActionType.Call:
                    return new GameActionBet(this, bets.Max().Value);
                case ActionType.Bet:
                case ActionType.Raise:
                    if(bet.HasValue)
                        return new GameActionBet(this, bet.Value);
                    else
                        throw new InvalidOperationException("No bet was passed.");
                default:
                    throw new InvalidOperationException($"Action type {actionType.ToString()} is not suported by method.");
            }
        }

    }
}

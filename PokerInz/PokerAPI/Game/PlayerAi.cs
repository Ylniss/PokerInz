using PokerAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public abstract class PlayerAi : IPlayerAi
    {
        protected IList<Parameter> parameters = new List<Parameter>();

        public IList<ICard> HoleCards;
        public int Chips;
        public int CurrentBet;
        public int TablePosition;

        public int ChipsAndBet
        {
            get
            {
                return Chips + CurrentBet;
            }
        }

        public IList<Parameter> Parameters
        {
            get
            {
                return parameters;
            }
        }

        public int TakeAction(ITable table, ActionInfo actionInfo)
        {
            UpdateParams();
            return MakeDecision(table, actionInfo);
        }

        public abstract int MakeDecision(ITable table, ActionInfo actionInfo);

        public abstract void UpdateParams();
    }
}

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
        private IList<Parameter> parameters = new List<Parameter>();

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

        public IList<Parameter> Parameters //todo: czy to potrzebne?
        {
            get
            {
                return parameters;
            }
        }

        public PlayerAi(IList<Parameter> parameters)
        {
            this.parameters = parameters;
        }

        public abstract int TakeAction(ITable table, ActionInfo actionInfo);
    }
}

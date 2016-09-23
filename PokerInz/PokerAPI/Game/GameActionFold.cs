using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    class GameActionFold : IGameAction
    {
        public int Pot { get; set; }

        public int CurrentPlayerPosition { get; }

        public ITable Table { get; }

        public GameActionFold(IPlayer currentPlayer)
        {
            currentPlayer.IsActive = false;

            currentPlayer.Chips -= currentPlayer.Bet;
            Pot += currentPlayer.Bet;

            currentPlayer.Bet = 0;
        }
    }
}

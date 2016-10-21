using PokerAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public class GameActionFold : GameAction
    {
        public GameActionFold(IPlayer currentPlayer, ITable table) : base(table)
        {
            currentPlayer.PlayerState = PlayerState.Folded;

            currentPlayer.Chips -= currentPlayer.Bet;
            Table.Pot += currentPlayer.Bet;

            currentPlayer.Bet = 0;
        }
    }
}

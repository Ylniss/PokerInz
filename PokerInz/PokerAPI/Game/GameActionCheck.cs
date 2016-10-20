using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public class GameActionCheck : GameAction
    {
        public GameActionCheck(IPlayer currentPlayer, ITable table) : base(table)
        {
            if(currentPlayer.Bet < Table.PlayerBets.Values.Max())
                throw new ArgumentOutOfRangeException("Check is not possible, there is bet to call/raise/fold.");
        }
    }
}
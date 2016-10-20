using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public class GameActionBet : GameAction
    {
        public int Bet { get; }

        public GameActionBet(IPlayer currentPlayer, ITable table, int bet) : base(table)
        {
            if (bet < currentPlayer.Bet || bet > currentPlayer.Chips + currentPlayer.Bet || bet < Table.PlayerBets.Values.Max())
                throw new ArgumentOutOfRangeException("Bet is less or greater than expected.");

            currentPlayer.Chips += currentPlayer.Bet;
            table.PlayerBets[currentPlayer.Name] = currentPlayer.Bet = Bet = bet;
            currentPlayer.Chips -= bet;
        }

    }
}

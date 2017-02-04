using PokerAPI.Enums;
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
            if (bet < currentPlayer.Bet || bet > currentPlayer.Chips + currentPlayer.Bet || (bet < Table.PlayerBets.Values.Max() && bet < currentPlayer.Chips + currentPlayer.Bet))
                throw new ArgumentOutOfRangeException("Bet is less or greater than expected.");

            if(table.GameStage == GameStage.Flop && bet < table.BigBlind)
                throw new ArgumentOutOfRangeException("Bet should be greater or equal than big blind during Flop.");

            if ((table.GameStage == GameStage.Turn || table.GameStage == GameStage.River) && bet < 2*table.BigBlind)
                throw new ArgumentOutOfRangeException("Bet should be greater or equal than two times big blind during Turn and River.");

            if (bet > Table.PlayerBets.Values.Max())
                currentPlayer.PlayerState = PlayerState.Raised;
            else if (bet == Table.PlayerBets.Values.Max())
                currentPlayer.PlayerState = PlayerState.Called;

            currentPlayer.Bet = Bet = bet;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public class GameActionBet : IGameAction
    {
        public int CurrentPlayerPosition { get; }

        public int Bet { get; }

        public ITable Table { get; }

        public GameActionBet(IPlayer currentPlayer, int bet)
        {
            if (bet < currentPlayer.Bet || bet > currentPlayer.Chips || bet < Table.PlayerBets.Max().Value)
                throw new ArgumentOutOfRangeException("Bet is less or greater than expected.");

            currentPlayer.Bet = Bet = bet;
        }
    }
}

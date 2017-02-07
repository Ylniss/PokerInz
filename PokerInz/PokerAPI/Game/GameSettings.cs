using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public class GameSettings
    {
        public IDictionary<IPlayer, int> PlayersStartingCash = new Dictionary<IPlayer, int>();

        public int SmallBlind { get; }

        public int BigBlind { get; }

        public bool Performance { get; }

        public int NumberOfGames { get; }

        public GameSettings(IDictionary<IPlayer, int> playersStartingCash, int smallblind, int bigBlind, bool performance, int numberOfGames)
        {
            PlayersStartingCash = playersStartingCash;
            SmallBlind = smallblind;
            BigBlind = bigBlind;
            Performance = performance;
            NumberOfGames = numberOfGames;
        }
    }
}

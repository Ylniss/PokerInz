using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAPI.Game
{
    public class PlayersStats
    {
        public IDictionary<IPlayer, int> PlayerPerformanceScores = new Dictionary<IPlayer, int>();

        public IDictionary<IPlayer, int> PlayersWinCount = new Dictionary<IPlayer, int>();

        private int numberOfGames;

        public PlayersStats(int numberOfGames)
        {
            this.numberOfGames = numberOfGames;
        }

        public float GetWinPercent(IPlayer player)
        {
            if (PlayersWinCount.ContainsKey(player))
                return (float)PlayersWinCount[player] / (float)numberOfGames * 100f;
            else
                return 0;
        }

        public float GetScorePercent(IPlayer player)
        {
            return (float)PlayerPerformanceScores[player] / (float)((PlayerPerformanceScores.Count - 1) * numberOfGames) * 100f;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Models;
using SamuraiDojo.Repositories;

namespace SamuraiDojo.Scoring
{
    internal class RankCalculator
    {
        public static void Calculate()
        {
            List<Player> players = PlayerRepository.Players.Values.ToList();
            players.Sort();

            HashSet<int> rankings = new HashSet<int>();
            int currentRank = 1;
            for (int i = 0; i < players.Count; i++)
            {
                if (!rankings.Contains(currentRank))
                {
                    players[i].Rank = currentRank;
                    rankings.Add(currentRank);
                }
                else
                    players[i].Rank = currentRank;

                if (i < players.Count - 1)
                    currentRank += Math.Abs(players[i].CompareTo(players[i + 1]));
            }
        }
    }
}

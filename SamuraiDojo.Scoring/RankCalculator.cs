using System;
using System.Collections.Generic;
using System.Linq;
using SamuraiDojo.IOC;
using SamuraiDojo.IOC.Interfaces;
using SamuraiDojo.Models;
using SamuraiDojo.Repositories;

namespace SamuraiDojo.Scoring
{
    /// <summary>
    /// Logic to determine players' ranks. This ranking is the OVERALL ranking, not
    /// battle-specific. This should ONLY be called after all points have been 
    /// assigned. This should be the last step during scoring.
    /// </summary>
    internal class RankCalculator : IRankCalculator
    {
        /// <summary>
        /// Players are ranked according to total historical points. If you have the 
        /// same number of total points, then the player who has participated in 
        /// fewer battles will be ranked higher, since they have accumulated their
        /// points in fewer battles. Multiple players CAN share the same rank if 
        /// they both match on all ranking criteria.
        /// </summary>
        public void Calculate()
        {
            List<IPlayer> players = Factory.Get<IPlayerRepository>().Players.Values.ToList();
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

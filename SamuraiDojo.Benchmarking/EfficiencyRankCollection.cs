using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Models;

namespace SamuraiDojo.Benchmarking
{
    public class EfficiencyRankCollection
    {
        private Dictionary<int, List<BattleResult>> efficiencyBuckets;

        public EfficiencyRankCollection()
        {
            efficiencyBuckets = new Dictionary<int, List<BattleResult>>();
        }

        public void Add(int rank, BattleResult battleResult)
        {
            if (efficiencyBuckets.ContainsKey(rank))
                efficiencyBuckets[rank].Add(battleResult);
            else
                efficiencyBuckets.Add(rank, new List<BattleResult> { battleResult });
        }

        public void Add(int rank, IEnumerable<BattleResult> battleResults)
        {
            foreach (BattleResult result in battleResults)
                Add(rank, result);
        }

        public List<BattleResult> Get(int rank)
        {
            List<BattleResult> resultsForRank = new List<BattleResult>();
            if (efficiencyBuckets.ContainsKey(rank))
                resultsForRank = efficiencyBuckets[rank];

            return resultsForRank;
        }

        public bool HasRank(int rank)
        {
            return efficiencyBuckets.ContainsKey(rank);
        }

        public int RankCount()
        {
            return efficiencyBuckets.Keys.Count;
        }
    }
}

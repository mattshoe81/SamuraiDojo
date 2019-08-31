using System;
using System.Collections.Generic;
using System.Linq;
using SamuraiDojo.Benchmarking.Interfaces;
using SamuraiDojo.IOC;
using SamuraiDojo.Models;

namespace SamuraiDojo.Benchmarking
{
    public class EfficiencyCalculator : IEfficiencyCalculator
    {
        public double MarginScalar { get; set; } = 2.0;

        public double Margin { get; private set; }

        private double minStdDev;

        public IEfficiencyRankCollection RankBattleResults(List<PlayerBattleResult> battleResults)
        {
            IEfficiencyRankCollection efficiencyRankCollection = Factory.New<IEfficiencyRankCollection>();
            minStdDev = battleResults.Min(result => result.Efficiency.StandardDeviation);
            int rank = 1;

            battleResults = battleResults.OrderBy(result => result.Efficiency.AverageExecutionTime).ToList();
            while (battleResults.Count > 0)
            {
                PlayerBattleResult nextMostEfficient = battleResults[0];
                Margin = CalculateMargin(nextMostEfficient);
                double baseline = nextMostEfficient.Efficiency.AverageExecutionTime;

                PlayerBattleResult[] resultsWithSimilarEfficiency =
                    battleResults
                    .Where(result => IsWithinMargin(result, baseline))
                    .OrderBy(result => result.Efficiency.MemoryAllocated).ToArray();

                battleResults.RemoveAll(result => resultsWithSimilarEfficiency.Contains(result));

                efficiencyRankCollection.Add(rank, resultsWithSimilarEfficiency);
                rank++;
            }

            return efficiencyRankCollection;
        }

        private double CalculateMargin(PlayerBattleResult result)
        {
            return minStdDev * MarginScalar;
        }

        private bool IsWithinMargin(PlayerBattleResult battleResult, double baseline)
        {
            double difference = battleResult.Efficiency.AverageExecutionTime - baseline;
            bool result = Math.Abs(difference) <= Margin;

            return result;
        }
    }
}

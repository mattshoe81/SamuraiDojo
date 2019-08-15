using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using SamuraiDojo.Attributes;
using SamuraiDojo.Models;
using SamuraiDojo.Repositories;
using SamuraiDojo.Test;
using SamuraiDojo.Test.Attributes;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Benchmarking
{
    public class Program
    {
        private static readonly ConsoleColor TEXT_COLOR;

        static Program()
        {
            TEXT_COLOR = ConsoleColor.Green;
        }

        public static void Main(string[] args)
        {
#if DEBUG
            RejectStart();
            return;
#endif
            Console.WindowWidth = 200;
            Console.ForegroundColor = TEXT_COLOR;

            while (true)
                Iterate();
        }

        private static void RejectStart()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{Environment.NewLine}IN ORDER TO RUN BENCHMARKING, YOU MUST RUN IN RELEASE MODE WITHOUT DEBUGGING!!");
            Console.WriteLine($"NOTE: You must run this using 'Debug' -> 'Start Without Debugging' or you will not get real results.");
            Console.ReadKey();
        }

        private static void Iterate()
        {
            PrintBattleOptions(BattleCollection.All);
            Console.Write($"Select the above index for the challenge you wish to Benchmark: ");
            string input = Console.ReadLine();

            int battleIndex = 0;
            if (int.TryParse(input, out battleIndex) && battleIndex >= 0 && battleIndex < BattleCollection.Count)
            {
                BattleAttribute battle = BattleCollection.Get(battleIndex);
                List<BattleResult> battleResults = BenchmarkEngine.PerformBenchmarking(battle);

                EfficiencyCalculator efficiencyCalculator = new EfficiencyCalculator();
                EfficiencyRankCollection ranks = efficiencyCalculator.RankBattleResults(battleResults);
                PrintBenchmarkingResults(ranks, efficiencyCalculator);
            }
            else
            {
                Console.WriteLine($"Invalid Input!{Environment.NewLine}");
            }
        }

        private static void PrintBattleOptions(List<BattleAttribute> battles)
        {
            for (int i = 0; i < battles.Count; i++)
                Console.WriteLine($"\t{i}:\t''{battles[i].Name}', {battles[i].Deadline.ToShortDateString()}");
        } 

        private static void PrintBenchmarkingResults(EfficiencyRankCollection efficiencyBuckets, EfficiencyCalculator efficiencyCalculator)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Benchmarking results:");
            Console.WriteLine($"Margin: {efficiencyCalculator.Margin}   --   ({efficiencyCalculator.MarginScalar} of Minimum StdDev)");

            int rank = 1;
            while (efficiencyBuckets.HasRank(rank))
            {
                List<BattleResult> results = efficiencyBuckets.Get(rank);
                Console.WriteLine($"Rank {rank}");
                foreach (BattleResult result in results)
                {
                    Console.WriteLine($"\t{result.Player.Name}");
                    Console.WriteLine($"\t\tAverage Exec Time: \t{result.Efficiency.AverageExecutionTime} nanoseconds");
                }
                rank++;
            }

            Console.ForegroundColor = TEXT_COLOR;
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

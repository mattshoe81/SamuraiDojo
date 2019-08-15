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
        private static readonly int WIDTH;
        private static readonly int HEIGHT;

        static Program()
        {
            WIDTH = 180;
            HEIGHT = 40;
            TEXT_COLOR = ConsoleColor.Green;

            Console.WindowWidth = WIDTH;
            Console.WindowHeight = HEIGHT;
            Console.ForegroundColor = TEXT_COLOR;
        }

        public static void Main(string[] args)
        {
#if DEBUG
            RejectStart();
            //return;
#endif
            while (true)
                Iterate();
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
                Console.WriteLine("Starting benchmarking");
                List<BattleResult> battleResults = BenchmarkEngine.PerformBenchmarking(battle);
                Console.WriteLine("Benchmarking completed");

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
            Console.WriteLine($"Margin: {efficiencyCalculator.Margin}   --   ({efficiencyCalculator.MarginScalar * 100}% of Minimum Standard Deviation)");

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

        private static void RejectStart()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{Environment.NewLine}IN ORDER TO RUN BENCHMARKING, YOU MUST RUN IN RELEASE MODE WITHOUT DEBUGGING!!");
            Console.WriteLine($"NOTE: You must run this using 'Debug' -> 'Start Without Debugging' or you will not get real results.");
            Console.ReadKey();
        }
    }
}

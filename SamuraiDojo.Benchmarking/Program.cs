using System;
using System.Collections.Generic;
using SamuraiDojo.Attributes;
using SamuraiDojo.Models;

namespace SamuraiDojo.Benchmarking
{
    public class Program
    {
        private static readonly ConsoleColor DEFAULT_COLOR;
        private static readonly ConsoleColor INFO_COLOR;
        private static readonly ConsoleColor ERROR_COLOR;
        private static readonly int WIDTH;
        private static readonly int HEIGHT;

        private static BattleAttribute CurrentBattle;

        static Program()
        {
            WIDTH = 180;
            HEIGHT = 40;
            DEFAULT_COLOR = ConsoleColor.Yellow;
            INFO_COLOR = ConsoleColor.DarkYellow;
            ERROR_COLOR = ConsoleColor.DarkRed;
            
            Console.WindowWidth = WIDTH;
            Console.WindowHeight = HEIGHT;
            Console.ForegroundColor = DEFAULT_COLOR;
        }

        public static void Main(string[] args)
        {
#if DEBUG
            RejectStart();
            return;
#endif
            while (true)
                Iterate();
        }

        private static void Iterate()
        {
            string input = GetInput();
            int battleIndex = 0;

            if (int.TryParse(input, out battleIndex) && battleIndex >= 0 && battleIndex < BattleCollection.Count)
                BenchmarkBattle(battleIndex);
            else
                PrintError($"{Environment.NewLine}Invalid Input!{Environment.NewLine}");
        }

        private static string GetInput()
        {
            PrintBattleOptions(BattleCollection.All);
            Console.Write($"Enter the index of the battle you wish to Benchmark: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            return input;
        }

        private static void BenchmarkBattle(int index)
        {
            CurrentBattle = BattleCollection.Get(index);
            List<BattleResult> battleResults = BenchmarkEngine.PerformBenchmarking(CurrentBattle);

            EfficiencyCalculator efficiencyCalculator = new EfficiencyCalculator();
            EfficiencyRankCollection ranks = efficiencyCalculator.RankBattleResults(battleResults);
            PrintBenchmarkingResults(ranks, efficiencyCalculator);
        }

        private static void PrintBattleOptions(List<BattleAttribute> battles)
        {
            Console.ForegroundColor = INFO_COLOR;
            Console.WriteLine();
            string battleOptionsHeader = $"History of All Battles{Environment.NewLine}";
            int dividerLength = 80;
            PrintDivider(dividerLength);
            Console.WriteLine(battleOptionsHeader);
            for (int i = 0; i < battles.Count; i++)
                Console.WriteLine($"\t{i}:\t'{battles[i].Name}', {battles[i].Deadline.ToShortDateString()}");
            PrintDivider(dividerLength);
            Console.WriteLine();
            Console.ForegroundColor = DEFAULT_COLOR;
        }

        private static void PrintBenchmarkingResults(EfficiencyRankCollection efficiencyBuckets, EfficiencyCalculator efficiencyCalculator)
        {
            Console.ForegroundColor = INFO_COLOR;
            int headerLength = PrintBenchmarkHeader(efficiencyBuckets, efficiencyCalculator);

            int rank = 1;
            while (efficiencyBuckets.HasRank(rank))
            {
                List<BattleResult> results = efficiencyBuckets.Get(rank);
                Console.WriteLine($"Rank {rank}");
                foreach (BattleResult result in results)
                {
                    Console.WriteLine($"\t{result.Player.Name}");
                    Console.WriteLine("\t\tAverage Exec Time: \t{0:0,0.000} nanoseconds", result.Efficiency.AverageExecutionTime);
                    Console.WriteLine($"\t\tMemory Allocated: \t{result.Efficiency.MemoryAllocated.ToString("N0")} Bytes");
                }
                rank++;
            }

            PrintBenchmarkFooter(headerLength);
        }

        private static int PrintBenchmarkHeader(EfficiencyRankCollection efficiencyBuckets, EfficiencyCalculator efficiencyCalculator)
        {
            Console.WriteLine();
            Console.WriteLine();

            string headerString = $"=====   Benchmarking for '{CurrentBattle.Name}'   ======";
            PrintDivider(headerString.Length);
            Console.WriteLine(headerString);
            PrintDivider(headerString.Length);
            Console.WriteLine($"Margin: {efficiencyCalculator.Margin}  --  (Grouped as being {efficiencyCalculator.MarginScalar} standard deviation(s) from the most efficient mean in that rank.)");
            Console.WriteLine();

            return headerString.Length;
        }

        private static void PrintDivider(int length)
        {
            for (int i = 0; i < length; i++)
                Console.Write("=");
            Console.WriteLine();
        }

        private static void PrintBenchmarkFooter(int headerLength)
        {
            Console.WriteLine();
            PrintDivider(headerLength);
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = DEFAULT_COLOR;
        }

        private static void RejectStart()
        {
            Console.ForegroundColor = ERROR_COLOR;
            Console.WriteLine($"{Environment.NewLine}IN ORDER TO RUN BENCHMARKING, YOU MUST RUN IN RELEASE MODE WITHOUT DEBUGGING!!");
            Console.WriteLine($"NOTE: You must run this using 'Debug' -> 'Start Without Debugging' or you will not get real results.");
            Console.ReadLine();
        }

        private static void PrintError(string message)
        {
            Console.ForegroundColor = ERROR_COLOR;
            Console.WriteLine(message);
            Console.ForegroundColor = DEFAULT_COLOR;
        }
    }
}

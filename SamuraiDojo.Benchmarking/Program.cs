using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Horology;
using SamuraiDojo.Benchmarking.Benchmarks.IoC;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Benchmarking
{
    public class Program
    {
        private static readonly ConsoleColor DEFAULT_COLOR;
        private static readonly ConsoleColor INFO_COLOR; 
        private static readonly ConsoleColor ERROR_COLOR;
        private static readonly int WIDTH;
        private static readonly int HEIGHT;
        private static readonly Dictionary<TimeUnit, string> timeUnits;
        private static readonly Dictionary<SizeUnit, string> sizeUnits;

        public static TimeUnit TimeUnit { get; set; } = TimeUnit.Millisecond;
        public static SizeUnit SizeUnit { get; set; } = SizeUnit.B;

        private static IBattleAttribute SelectedBattle;
        private static IBattleCollection battleCollection;

        static Program()
        {
            new Benchmarking.Setup();
            battleCollection = Factory.Get<IBattleCollection>();

            WIDTH = 180;
            HEIGHT = 40;
            DEFAULT_COLOR = ConsoleColor.Yellow;
            INFO_COLOR = ConsoleColor.DarkYellow;
            ERROR_COLOR = ConsoleColor.DarkRed;

            Console.WindowWidth = WIDTH;
            Console.WindowHeight = HEIGHT;
            Console.ForegroundColor = DEFAULT_COLOR;

            timeUnits = new Dictionary<TimeUnit, string>
            {
                { TimeUnit.Nanosecond, "ns" },
                { TimeUnit.Microsecond, "micros" },
                { TimeUnit.Millisecond, "ms" },
                { TimeUnit.Second, "s" },
                { TimeUnit.Minute, "mins" }
            };
            sizeUnits = new Dictionary<SizeUnit, string>
            {
                { SizeUnit.B, "B" },
                { SizeUnit.KB, "KB" },
                { SizeUnit.MB, "MB" },
                { SizeUnit.GB, "GB" }
            };
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
            string[] input = GetInput();

            if (input[0].Trim().EqualsIgnoreCase("ioc"))
                BenchmarkIoC(input);
            else if (input[0].Trim().EqualsIgnoreCase("help"))
                PrintHelp();
            else
            {
                SetUnits(input);

                int battleIndex = 0;

                if (input.Length > 0 && int.TryParse(input[0], out battleIndex) && battleIndex >= 0 && battleIndex < Factory.Get<IBattleCollection>().Count)
                    BenchmarkBattle(battleIndex);
                else
                    PrintError($"{Environment.NewLine}Invalid Input!{Environment.NewLine}");
            }
        }

        private static string[] GetInput()
        {
            PrintBattleOptions(battleCollection.All);
            Console.Write($"Select Battle (type 'help' for a list of commands): ");

            string[] result = new string[] { string.Empty };
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                result = input.Split(' ');

            Console.WriteLine();

            return result;
        }

        private static void SetUnits(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                KeyValuePair<TimeUnit, string> timeUnit = timeUnits.Where(pair => pair.Value.EqualsIgnoreCase(input[i].Trim())).FirstOrDefault();
                if (timeUnit.Key != null)
                    TimeUnit = timeUnit.Key;
                else
                {
                    KeyValuePair<SizeUnit, string> sizeUnit = sizeUnits.Where(pair => pair.Value.EqualsIgnoreCase(input[i].Trim())).FirstOrDefault();
                    if (sizeUnit.Key != null)
                        SizeUnit = sizeUnit.Key;
                }
            }
        }

        private static void PrintHelp()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            PrintDivider(100);
            Console.WriteLine("\tHow to use this command line");
            PrintDivider(100);
            Console.WriteLine();

            Console.WriteLine($"You must always enter a battle index (except to load this view)");
            Console.WriteLine($"You can also specify one or both of the units for time and memory you wish to use.");
            Console.WriteLine($"Simply enter the battle index, one or both of the units you want, separating each by at least one space.");
            Console.WriteLine($"The order in which you enter the unit arguments does not matter, but the battle index MUST be first");
            Console.WriteLine();

            Console.WriteLine("Time Units:");
            foreach (KeyValuePair<TimeUnit, string> pair in timeUnits)
                Console.WriteLine($"\t{pair.Value}");

            Console.WriteLine("Size Units:");
            foreach (KeyValuePair<SizeUnit, string> pair in sizeUnits)
                Console.WriteLine($"\t{pair.Value}");

            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("\t2 ms kb");
            Console.WriteLine("\t0 b ns");
            Console.WriteLine("\t3 micros");
            Console.WriteLine("\t1 mb");

            Console.WriteLine();
            PrintDivider(100);
            Console.WriteLine();
            Console.Write("Press any key to continue ");
            Console.ReadKey();
            Console.WriteLine();
            Console.ForegroundColor = DEFAULT_COLOR;
        }

        private static void BenchmarkIoC(string[] input)
        {
            Factory.Get<IBenchmarkEngine>().PerformBenchmarking(typeof(IoCBenchmarking));
        }

        private static void BenchmarkBattle(int index)
        {
            SelectedBattle = Factory.Get<IBattleCollection>().Get(index);
            List<IPlayerBattleResult> battleResults = Factory.Get<IBenchmarkEngine>().PerformBenchmarking(SelectedBattle);

            IEfficiencyCalculator efficiencyCalculator = Factory.Get<IEfficiencyCalculator>();
            IEfficiencyRankCollection ranks = efficiencyCalculator.RankBattleResults(battleResults);
            PrintBenchmarkingResults(ranks, efficiencyCalculator);
        }

        private static void PrintBattleOptions(List<IBattleAttribute> battles)
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

        private static void PrintBenchmarkingResults(IEfficiencyRankCollection efficiencyBuckets, IEfficiencyCalculator efficiencyCalculator)
        {
            Console.ForegroundColor = INFO_COLOR;
            int headerLength = PrintBenchmarkHeader(efficiencyBuckets, efficiencyCalculator);

            int rank = 1;
            while (efficiencyBuckets.HasRank(rank))
            {
                List<IPlayerBattleResult> results = efficiencyBuckets.Get(rank);
                Console.WriteLine($"Rank {rank}");
                foreach (IPlayerBattleResult result in results)
                {
                    Console.WriteLine($"\t{result.Player.Name}");
                    Console.WriteLine("\t\tAverage Exec Time: \t{0:0,0.000} {1}", result.Efficiency.AverageExecutionTime, timeUnits[TimeUnit]);
                    Console.WriteLine($"\t\tMemory Allocated: \t{result.Efficiency.MemoryAllocated.ToString("N0")} {sizeUnits[SizeUnit]}");
                }
                rank++;
            }

            PrintBenchmarkFooter(headerLength);
        }

        private static int PrintBenchmarkHeader(IEfficiencyRankCollection efficiencyBuckets, IEfficiencyCalculator efficiencyCalculator)
        {
            Console.WriteLine();
            Console.WriteLine();

            string headerString = $"=====   Benchmarking for '{SelectedBattle.Name}'   ======";
            PrintDivider(headerString.Length);
            Console.WriteLine(headerString);
            PrintDivider(headerString.Length);
            Console.WriteLine($"Players are grouped into ranks where each rank contains all players whose mean is {efficiencyCalculator.MarginScalar} standard deviation(s) from the most efficient mean in that rank.");
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

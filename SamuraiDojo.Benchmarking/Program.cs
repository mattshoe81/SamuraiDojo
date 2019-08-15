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
        private static List<BattleResult> battleResults;

        public static void Main(string[] args)
        {
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Environment.NewLine}IN ORDER TO RUN BENCHMARKING, YOU MUST RUN IN RELEASE MODE WITHOUT DEBUGGING!!");
            Console.WriteLine($"NOTE: You must run this using 'Debug' -> 'Start Without Debugging' or you will not get real results.");
            Console.ReadKey();
            return;
#endif
            battleResults = new List<BattleResult>();

            Type[] battleTypes = 
                ReflectionUtility.LoadTypesWithAttribute<BattleAttribute>("SamuraiDojo")
                .Where(type => !AttributeUtility.HasAttribute<WrittenByAttribute>(type))
                .OrderByDescending(type => AttributeUtility.GetAttribute<BattleAttribute>(type).Deadline).ToArray();

            Tuple<Type, BattleAttribute>[] battles = new Tuple<Type, BattleAttribute>[battleTypes.Length];
            for (int i = 0; i < battleTypes.Length; i++)
            {
                BattleAttribute battleAttribute = AttributeUtility.GetAttribute<BattleAttribute>(battleTypes[i]);
                battles[i] = new Tuple<Type, BattleAttribute>(battleTypes[i], battleAttribute);
            }

            while (true)
            {
                battleResults.Clear();
                PrintBattleOptions(battles);
                Console.Write($"Select the above index for the challenge you wish to Benchmark: ");
                string input = Console.ReadLine();
                int battleIndex = 0;
                if (int.TryParse(input, out battleIndex))
                {
                    PerformBenchmarking(battles[battleIndex].Item1);
                    PrintBenchmarkingResults();
                }
                else
                {
                    Console.WriteLine($"Invalid Input!{Environment.NewLine}");
                }
            }
        }

        private static void PrintBattleOptions(Tuple<Type, BattleAttribute>[] battles)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < battles.Length; i++)
                Console.WriteLine($"\t{i}:\t''{battles[i].Item2.Name}', {battles[i].Item2.Deadline.ToShortDateString()}");

            Console.ForegroundColor = ConsoleColor.White;
        } 

        private static void PerformBenchmarking(Type battleType)
        {
            Type[] battleSolutions = 
                ReflectionUtility.LoadTypesWithAttribute<WrittenByAttribute>("SamuraiDojo.Test")
                .Where(type => AttributeUtility.GetAttribute<UnderTestAttribute>(type).Type.FullName == battleType.FullName).ToArray();

            foreach (Type type in battleSolutions)
            {
                double efficiency = CalculateAlgorithmEfficiency(type);

                WrittenByAttribute writtenBy = AttributeUtility.GetAttribute<WrittenByAttribute>(type);
                BattleResult battleResult = new BattleResult
                {
                    Efficiency = efficiency,
                    Player = writtenBy
                };
                battleResults.Add(battleResult);
            }
        }

        private static double CalculateAlgorithmEfficiency(Type type)
        {
            Summary summary = RunBenchmarking(type);
            double efficiency = GetEfficiencyScore(summary);
            //double efficiency = new EfficiencyCalculator().AnalyzeTests(type);

            return efficiency;
        }

        private static Summary RunBenchmarking(Type type)
        {
            IConfig config = DefaultConfig.Instance.With(ConfigOptions.DisableOptimizationsValidator);
            TestRunner testRunner = new TestRunner();
            BattleBenchmarkRunner.Action = () =>
            {
                testRunner.RunTests(type);
            };
#if DEBUG
            Summary summary = BenchmarkRunner.Run<BattleBenchmarkRunner>(config);
#endif
#if !DEBUG
            Summary summary = BenchmarkRunner.Run<BattleBenchmarkRunner>();
#endif
            if (summary.ValidationErrors != null && summary.ValidationErrors.Length > 0)
            {
                foreach (ValidationError error in summary.ValidationErrors)
                    Log.Error($"Benchmarking Validation Error: {Environment.NewLine}\t{error.Message}");
            }
            else
                Log.Info($"No Validation Errors encountered.");

            return summary;
        }

        private static double GetEfficiencyScore(Summary summary)
        {
            double meanEfficiency = 0;
            try
            {
                BenchmarkCase benchmark = summary.BenchmarksCases[0];
                IColumn meanColumn = summary.GetColumns().Where(column => column.ColumnName.ToUpper() == "MEAN").FirstOrDefault();
                string meanString = meanColumn.GetValue(summary, benchmark, new SummaryStyle(true, SizeUnit.B, TimeUnit.Nanosecond, false));
                Log.Info("Mean String: " + meanString);
                meanEfficiency = double.Parse(meanString.Replace(",", ""));
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
                meanEfficiency = 0;
            }

            return meanEfficiency;
        }

        private static void PrintBenchmarkingResults()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            battleResults = battleResults.OrderBy(result => result.Efficiency).ToList();
            Console.WriteLine($"Benchmarking results in order of efficiency:{Environment.NewLine}");
            for (int i = 0; i < battleResults.Count; i++)
                Console.WriteLine($"{i + 1}: \t {battleResults[i].Player.Name} -- {battleResults[i].Efficiency} ticks");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}

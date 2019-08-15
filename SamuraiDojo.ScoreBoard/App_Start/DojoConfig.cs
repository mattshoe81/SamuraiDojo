using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace SamuraiDojo.ScoreBoard.App_Start
{
    public static class DojoConfig
    {
        public static void Init()
        {
            ClearLogFile();
            SamuraiDojo.Auditor.Audit();
            RunUnitTests();
            RunBenchmarking();
            CalculateRanks();
        }

        private static void ClearLogFile()
        {
            try
            {
                File.WriteAllText(Log.OUTPUT_PATH, string.Empty);
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }

        private static void RunUnitTests()
        {
            TestRunner testRunner = new TestRunner();

            SetPreTestAction(testRunner);
            SetPassedTestAction(testRunner);

            testRunner.Run();
        }

        private static void SetPreTestAction(TestRunner testRunner)
        {
            testRunner.PreTest = (context) =>
            {
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);
                BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(context.ClassUnderTest);
                battle.Sensei = sensei;
                PlayerRepository.AddPlayer(sensei.Name);

                BattleRepository.AddBattle(battle, sensei);
            };
        }

        private static void SetPassedTestAction(TestRunner testRunner)
        {
            testRunner.OnTestPass = (context) =>
            {
                BattleAttribute battle = AttributeUtility.GetAttribute<BattleAttribute>(context.ClassUnderTest);
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);

                if (!sensei.Name.EqualsIgnoreCase(context.WrittenBy.Name))
                {
                    int points = 1;
                    PlayerRepository.AddPoint(context.WrittenBy.Name, context.ClassUnderTest, points);
                    BattleRepository.AddPlayerPoint(battle, context.WrittenBy, points);
                }

            };
        }

        private static void RunBenchmarking()
        {
            Benchmarking.Program.Main(new string[0]);
        }

        private static void CalculateRanks()
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
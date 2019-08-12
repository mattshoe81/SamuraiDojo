using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            SamuraiDojo.Auditor.Audit();
            RunUnitTests();
            CalculateRanks();
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
                ChallengeAttribute challenge = AttributeUtility.GetAttribute<ChallengeAttribute>(context.ClassUnderTest);
                challenge.Sensei = sensei;
                PlayerRepository.AddPlayer(sensei.Name);

                ChallengeRepository.AddChallenge(challenge, sensei);
            };
        }

        private static void SetPassedTestAction(TestRunner testRunner)
        {
            testRunner.OnTestPass = (context) =>
            {
                ChallengeAttribute challenge = AttributeUtility.GetAttribute<ChallengeAttribute>(context.ClassUnderTest);
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);

                if (!sensei.Name.EqualsIgnoreCase(context.WrittenBy.Name))
                {
                    int points = 1;
                    PlayerRepository.AddPoint(context.WrittenBy.Name, context.ClassUnderTest, points);
                    ChallengeRepository.AddPlayerPoint(challenge, context.WrittenBy, points);
                }

            };
        }

        private static void CalculateRanks()
        {
            List<PlayerStats> players = PlayerRepository.Players.Values.ToList();
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
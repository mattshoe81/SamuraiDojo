using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SamuraiDojo.Attributes;
using SamuraiDojo.Stats;
using SamuraiDojo.Test;
using SamuraiDojo.Test.Attributes;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard.App_Start
{
    public static class DojoConfig
    {
        public static void Init()
        {
            RunSamuraiDojoAuditor();
            RunUnitTests();
        }

        private static void RunUnitTests()
        {
            TestRunner testRunner = new TestRunner();

            testRunner.PreTest = (context) =>
            {
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);
                ChallengeAttribute challenge = AttributeUtility.GetAttribute<ChallengeAttribute>(context.ClassUnderTest);
                challenge.Sensei = sensei;
                ScoreKeeper.AddPlayer(sensei.Name);

                ChallengeRepository.AddChallenge(challenge, sensei);
            };

            testRunner.OnTestPass = (context) =>
            {
                ChallengeAttribute challenge = AttributeUtility.GetAttribute<ChallengeAttribute>(context.ClassUnderTest);
                SenseiAttribute sensei = AttributeUtility.GetAttribute<SenseiAttribute>(context.ClassUnderTest);

                if (!sensei.Name.EqualsIgnoreCase(context.WrittenBy.Name))
                {
                    int points = 1;
                    ScoreKeeper.AddPoint(context.WrittenBy.Name, context.ClassUnderTest, points);
                    ChallengeRepository.AddPlayerPoint(challenge, context.WrittenBy, points);
                }

            };
            testRunner.Run();
            CalculateRanks();

            foreach (KeyValuePair<string, PlayerStats> pair in ScoreKeeper.Players)
                Debug.WriteLine($"{pair.Key}:\t{pair.Value.TotalPoints}");
        }

        private static void CalculateRanks()
        {
            List<PlayerStats> players = ScoreKeeper.Players.Values.ToList();
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

        private static void RunSamuraiDojoAuditor()
        {
            SamuraiDojo.Auditor.Audit();
        }
    }
}
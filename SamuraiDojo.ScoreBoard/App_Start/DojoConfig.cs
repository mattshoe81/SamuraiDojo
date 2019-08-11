﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using SamuraiDojo.Attributes;
using SamuraiDojo.Stats;
using SamuraiDojo.Test;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard.App_Start
{
    public static class DojoConfig
    {
        public static void Init()
        {
            RunUnitTests();
            RunSamuraiAuditor();
        }

        private static void RunUnitTests()
        {
            TestRunner testRunner = new TestRunner();

            testRunner.OnTestPass = (context) =>
            {
                ScoreKeeper.AddPoint(context.WrittenBy.Name, context.ClassUnderTest);

                ChallengeAttribute challenge = AttributeUtility.GetAttribute<ChallengeAttribute>(context.ClassUnderTest);
                ChallengeRepository.AddPlayerPoint(challenge, context.WrittenBy);
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

        public static void RunSamuraiAuditor()
        {
            SamuraiDojo.Auditor.Audit();
        }
    }
}
using System;
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
            TestRunner testRunner = new TestRunner();
            testRunner.OnTestPass = (context) =>
            {
                ScoreKeeper.AddPoint(context.WrittenBy, context.ClassUnderTest);
                ChallengeAttribute challenge = AttributeUtility.GetAttribute<ChallengeAttribute>(context.ClassUnderTest);

            };
            testRunner.Run();

            foreach (KeyValuePair<string, PlayerStats> pair in ScoreKeeper.Players)
                Debug.WriteLine($"{pair.Key}:\t{pair.Value.TotalPoints}");
        }
    }
}
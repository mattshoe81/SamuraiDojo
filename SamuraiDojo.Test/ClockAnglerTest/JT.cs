﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Challenges;

namespace SamuraiDojo.Test.ClockAnglerTest
{
    [TestClass]
    [SolutionBy(Samurai.JT)]
    public class JT : ClockAnglerTestBase
    {
        protected override int Calculate(int hour, int minute)
        {
            return ClockAngler.JT_CalculateAngleBetweenHands(hour, minute);
        }
    }
}

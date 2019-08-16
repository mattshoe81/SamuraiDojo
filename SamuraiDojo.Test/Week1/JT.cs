﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week1;

namespace SamuraiDojo.Test.Week1
{
    [TestClass]
    [WrittenBy(Samurai.JT)]
    public class JT : ClockAnglerTestBase
    {
        protected override int Calculate(int hour, int minute)
        {
            return ClockAngler.JT_CalculateAngleBetweenHands(hour, minute);
        }
    }
}

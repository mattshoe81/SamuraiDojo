﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamuraiDojo.Test.ClockAnglerTest
{
    [TestClass]
    public class JT : ClockAnglerTestBase
    {
        protected override int Calculate(int hour, int minute)
        {
            return ClockAngler.JT_CalculateAngleBetweenHands(hour, minute);
        }
    }
}

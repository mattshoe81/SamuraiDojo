using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Challenges;
using System;


namespace SamuraiDojo.Test.ClockAnglerTest
{
    [TestClass]
    public class Dustin : ClockAnglerTestBase
    {
        protected override int Calculate(int hour, int minute)
        {
            return ClockAngler.Dustin_CalculateAngleBetweenHands(hour, minute);
        }
    }
}

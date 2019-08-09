using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Challenges;

namespace SamuraiDojo.Test.ClockAnglerTest
{
    [TestClass]
    [SolutionBy(Samurai.JEFF)]
    public class Jeff : ClockAnglerTestBase
    {
        protected override int Calculate(int hour, int minute)
        {
            return ClockAngler.Jeff_CalculateAngleBetweenHands(hour, minute);
        }
    }
}

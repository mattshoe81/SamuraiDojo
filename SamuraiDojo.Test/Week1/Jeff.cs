using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Challenges.Week1;
using SamuraiDojo.Test.Attributes;

namespace SamuraiDojo.Test.Week1
{
    [TestClass]
    [WrittenBy(Samurai.JEFF)]
    public class Jeff : ClockAnglerTestBase
    {
        protected override int Calculate(int hour, int minute)
        {
            return ClockAngler.Jeff_CalculateAngleBetweenHands(hour, minute);
        }
    }
}

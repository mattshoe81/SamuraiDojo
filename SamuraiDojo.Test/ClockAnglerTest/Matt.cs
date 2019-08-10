using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo;
using SamuraiDojo.Attributes;
using SamuraiDojo.Challenges;
using SamuraiDojo.Challenges.Week1;

namespace SamuraiDojo.Test.ClockAnglerTest
{
    [TestClass]
    [WrittenBy(Samurai.MATT)]
    public class Matt : ClockAnglerTestBase
    {
        protected override int Calculate(int hour, int minute)
        {
            return ClockAngler.Matt_CalculateAngleBetweenHands(hour, minute);
        }
    }
}

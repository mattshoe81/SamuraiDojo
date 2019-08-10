using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Challenges.Week1;

namespace SamuraiDojo.Test.ClockAnglerTest
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

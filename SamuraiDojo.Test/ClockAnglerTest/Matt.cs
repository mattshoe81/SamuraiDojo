using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo;
using SamuraiDojo.Attributes;
using SamuraiDojo.Challenges;

namespace SamuraiDojo.Test.ClockAnglerTest
{
    [TestClass]
    [SolutionByAttribute(Samurai.MATT)]
    public class Matt : ClockAnglerTestBase
    {
        protected override int Calculate(int hour, int minute)
        {
            return ClockAngler.Matt_CalculateAngleBetweenHands(hour, minute);
        }
    }
}

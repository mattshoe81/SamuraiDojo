using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles;
using SamuraiDojo.Battles.Week1;

namespace SamuraiDojo.Test.Week1
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

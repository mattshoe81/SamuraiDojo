using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week1;


namespace SamuraiDojo.Test.Week1
{
    [TestClass]
    [WrittenBy(Samurai.DUSTIN)]
    public class Dustin : ClockAnglerTestBase
    {
        protected override int Calculate(int hour, int minute)
        {
            return ClockAngler.Dustin_CalculateAngleBetweenHands(hour, minute);
        }
    }
}

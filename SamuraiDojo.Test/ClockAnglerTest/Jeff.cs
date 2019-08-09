using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Challenges;

namespace SamuraiDojo.Test.ClockAnglerTest
{
    [TestClass]
    public class Jeff : ClockAnglerTestBase
    {
        protected override int Calculate(int hour, int minute)
        {
            return ClockAngler.Jeff_CalculateAngleBetweenHands(hour, minute);
        }
    }
}

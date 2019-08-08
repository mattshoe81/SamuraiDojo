using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo;

namespace SamuraiDojo.Test.ClockAnglerTest
{
    [TestClass]
    public class Matt : ClockAnglerTestBase
    {
        protected override int Calculate(int hour, int minute)
        {
            return ClockAngler.Matt_CalculateAngleBetweenHands(hour, minute);
        }
    }
}

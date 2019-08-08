using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamuraiDojo.Test.ClockAnglerTest
{
    [TestClass]
    public abstract class ClockAnglerTestBase
    {

        protected abstract int Calculate(int hour, int minute);

        [TestMethod]
        public void TestMethod1()
        {
            int angle = Calculate(12, 15);
            int expected = 90;

            Assert.IsTrue(angle == expected || angle == 360 - expected, $"Expected {expected} or {360- expected} but found {angle}");
        }

        [TestMethod]
        public void TestMethod2()
        {
            int angle = Calculate(12, 0);
            int expected = 0;

            Assert.IsTrue(angle == expected || angle == 360 - expected, $"Expected {expected} or {360 - expected} but found {angle}");
        }

        [TestMethod]
        public void TestMethod3()
        {
            int angle = Calculate(12, 30);
            int expected = 180;

            Assert.IsTrue(angle == expected || angle == 360 - expected, $"Expected {expected} or {360 - expected} but found {angle}");
        }

        [TestMethod]
        public void TestMethod4()
        {
            int angle = Calculate(12, 45);
            int expected = 270;

            Assert.IsTrue(angle == expected || angle == 360 - expected, $"Expected {expected} or {360 - expected} but found {angle}");
        }

        [TestMethod]
        public void TestMethod5()
        {
            int angle = Calculate(3, 30);
            int expected = 90;

            Assert.IsTrue(angle == expected || angle == 360 - expected, $"Expected {expected} or {360 - expected} but found {angle}");
        }

        [TestMethod]
        public void TestMethod6()
        {
            int angle = Calculate(3, 45);
            int expected = 180;

            Assert.IsTrue(angle == expected || angle == 360 - expected, $"Expected {expected} or {360 - expected} but found {angle}");
        }

        [TestMethod]
        public void TestMethod7()
        {
            int angle = Calculate(6, 30);
            int expected = 0;

            Assert.IsTrue(angle == expected || angle == 360 - expected, $"Expected {expected} or {360 - expected} but found {angle}");
        }

        [TestMethod]
        public void TestMethod8()
        {
            int angle = Calculate(6, 15);
            int expected = 90;

            Assert.IsTrue(angle == expected || angle == 360 - expected, $"Expected {expected} or {360 - expected} but found {angle}");
        }

        [TestMethod]
        public void TestMethod9()
        {
            int angle = Calculate(9, 15);
            int expected = 180;

            Assert.IsTrue(angle == expected || angle == 360 - expected, $"Expected {expected} or {360 - expected} but found {angle}");
        }

        [TestMethod]
        public void TestMethod10()
        {
            int angle = Calculate(9, 0);
            int expected = 90;

            Assert.IsTrue(angle == expected || angle == 360 - expected, $"Expected {expected} or {360 - expected} but found {angle}");
        }


    }
}

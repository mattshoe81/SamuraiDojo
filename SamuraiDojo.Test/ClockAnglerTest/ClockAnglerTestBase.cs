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

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int angle = Calculate(12, 0);
            int expected = 0;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int angle = Calculate(12, 30);
            int expected = 180;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int angle = Calculate(12, 45);
            int expected = 270;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int angle = Calculate(3, 30);
            int expected = 90;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod6()
        {
            int angle = Calculate(3, 45);
            int expected = 180;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod7()
        {
            int angle = Calculate(6, 30);
            int expected = 0;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod8()
        {
            int angle = Calculate(6, 15);
            int expected = 90;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod9()
        {
            int angle = Calculate(9, 15);
            int expected = 180;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod10()
        {
            int angle = Calculate(9, 0);
            int expected = 90;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod11()
        {
            int angle = Calculate(1, 0);
            int expected = 30;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod12()
        {
            int angle = Calculate(2, 30);
            int expected = 105;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod13()
        {
            int angle = Calculate(7, 0);
            int expected = 150;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod14()
        {
            int angle = Calculate(10, 30);
            int expected = 135;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod15()
        {
            int angle = Calculate(11, 20);
            int expected = 140;

            AssertAngle(expected, angle);
        }

        [TestMethod]
        public void TestMethod16()
        {
            int angle = Calculate(3, 40);
            int expected = 130;

            AssertAngle(expected, angle);
        }

        private void AssertAngle(int expected, int angle)
        {
            Assert.IsTrue(angle == expected || angle == 360 - expected, $"Expected {expected} or {360 - expected} but found {angle}");
        }



    }
}

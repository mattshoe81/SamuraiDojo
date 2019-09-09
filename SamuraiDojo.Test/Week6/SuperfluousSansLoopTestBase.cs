using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Test.Attributes;
using SamuraiDojo.Battles.Week6;

namespace SamuraiDojo.Test
{
    [UnderTest(typeof(SuperfluousSansLoop))]
    [TestClass]
    public abstract class SuperfluousSansLoopTestBase : DojoTest<SuperfluousSansLoop>
    {

        private void AssertExpected(int inputParam, string expectedParam)
        {
            string actual = GetInstance().Print1toNWithoutLoops(inputParam);
            Assert.AreEqual(expectedParam, actual, $"{Environment.NewLine}Expected:\t{expectedParam.ToString()}{Environment.NewLine}Found:\t{actual.ToString()}");
        }

        [TestMethod]
        public override void Benchmark()
        {
            AssertExpected(
                100,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100"
            );
        }

        [TestMethod]
        public void TestMethod01()
        {
            AssertExpected(
                0,
                "0"
            );
        }


        [TestMethod]
        public void TestMethod02()
        {
            AssertExpected(
                1,
                "0, 1"
            );
        }


        [TestMethod]
        public void TestMethod03()
        {
            AssertExpected(
                2,
                "0, 1, 2"
            );
        }


        [TestMethod]
        public void TestMethod04()
        {
            AssertExpected(
                3,
                "0, 1, 2, 3"
            );
        }


        [TestMethod]
        public void TestMethod05()
        {
            AssertExpected(
                4,
                "0, 1, 2, 3, 4"
            );
        }


        [TestMethod]
        public void TestMethod06()
        {
            AssertExpected(
                5,
                "0, 1, 2, 3, 4, 5"
            );
        }


        [TestMethod]
        public void TestMethod07()
        {
            AssertExpected(
                6,
                "0, 1, 2, 3, 4, 5, 6"
            );
        }


        [TestMethod]
        public void TestMethod08()
        {
            AssertExpected(
                7,
                "0, 1, 2, 3, 4, 5, 6, 7"
            );
        }


        [TestMethod]
        public void TestMethod09()
        {
            AssertExpected(
                8,
                "0, 1, 2, 3, 4, 5, 6, 7, 8"
            );
        }


        [TestMethod]
        public void TestMethod10()
        {
            AssertExpected(
                9,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9"
            );
        }


        [TestMethod]
        public void TestMethod11()
        {
            AssertExpected(
                10,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10"
            );
        }


        [TestMethod]
        public void TestMethod12()
        {
            AssertExpected(
                11,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11"
            );
        }


        [TestMethod]
        public void TestMethod13()
        {
            AssertExpected(
                12,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12"
            );
        }


        [TestMethod]
        public void TestMethod14()
        {
            AssertExpected(
                13,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13"
            );
        }


        [TestMethod]
        public void TestMethod15()
        {
            AssertExpected(
                14,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14"
            );
        }


        [TestMethod]
        public void TestMethod16()
        {
            AssertExpected(
                15,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15"
            );
        }


        [TestMethod]
        public void TestMethod17()
        {
            AssertExpected(
                16,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16"
            );
        }


        [TestMethod]
        public void TestMethod18()
        {
            AssertExpected(
                17,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17"
            );
        }


        [TestMethod]
        public void TestMethod19()
        {
            AssertExpected(
                18,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18"
            );
        }


        [TestMethod]
        public void TestMethod20()
        {
            AssertExpected(
                19,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19"
            );
        }


        [TestMethod]
        public void TestMethod21()
        {
            AssertExpected(
                20,
                "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20"
            );
        }
    }
}

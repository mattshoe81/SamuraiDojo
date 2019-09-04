using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Test.Attributes;
using SamuraiDojo.Battles.Week#;

namespace SamuraiDojo.Test
{
    [UnderTest(typeof(YOUR_BATTLE_CLASS))]
    [TestClass]
    public abstract class YOUR_BATTLE_CLASSTestBase : DojoTest<YOUR_BATTLE_CLASS>
    {

        private void AssertExpected(INPUT_TYPE input, OUTPUT_TYPE expected)
        {
            OUTPUT_TYPE actual = GetInstance().RenameThis(input);
            Assert.AreEqual(expected, actual, $"{Environment.NewLine}Expected:\t{expected.ToString()}{Environment.NewLine}Found:\t{actual.ToString()}");
        }
        
        [TestMethod]
        public override void Benchmark()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod1()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod2()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod3()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod4()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod5()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod6()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod7()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod8()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod9()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod10()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod11()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod12()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod13()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod14()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod15()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod16()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod17()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod18()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod19()
        {
            AssertExpected(
                input,
                expected
            );
        }

        [TestMethod]
        public void TestMethod20()
        {
            AssertExpected(
                input,
                expected
            );
        }
    }
}

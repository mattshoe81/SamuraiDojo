using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Challenges.Week2;
using SamuraiDojo.Test.Attributes;

namespace SamuraiDojo.Test.Week2
{
    [TestClass]
    [UnderTest(typeof(CharacterCounter))]
    public abstract class BaseCharacterCounterTest
    {
        protected abstract CharacterCounter GetInstance();

        [TestMethod]
        public void TestMethod1()
        {
            RunTest("42", 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            RunTest("1111111111111111", 31);
        }

        [TestMethod]
        public void TestMethod3()
        {
            RunTest("9", 1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            RunTest("123", 5);
        }

        [TestMethod]
        public void TestMethod5()
        {
            RunTest("987654321", 10);
        }

        [TestMethod]
        public void TestMethod6()
        {
            RunTest("159486123548974896515361458674123136248941523106554169143548764153210348574153014184361064851053", 113);
        }

        [TestMethod]
        public void TestMethod7()
        {
            RunTest("999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999", 93);
        }

        [TestMethod]
        public void TestMethod8()
        {
            RunTest("1", 1);
        }

        [TestMethod]
        public void TestMethod9()
        {
            RunTest("1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111", 571);
        }

        [TestMethod]
        public void TestMethod10()
        {
            RunTest("27", 2);
        }

        [TestMethod]
        public void TestMethod11()
        {
            RunTest("26", 3);
        }

        [TestMethod]
        public void TestMethod12()
        {
            RunTest("921549817", 12);
        }

        [TestMethod]
        public void TestMethod13()
        {
            RunTest("42", 2);
        }

        [TestMethod]
        public void TestMethod14()
        {
            RunTest("0", 0);
        }

        [TestMethod]
        public void TestMethod15()
        {
            RunTest("00000000000000000000000000000000000", 0);
        }

        [TestMethod]
        public void TestMethod16()
        {
            RunTest("00", 0);
        }

        [TestMethod]
        public void TestMethod17()
        {
            RunTest("0123", 5);
        }

        [TestMethod]
        public void TestMethod18()
        {
            RunTest("01", 1);
        }

        [TestMethod]
        public void TestMethod19()
        {
            RunTest("001", 1);
        }

        [TestMethod]
        public void TestMethod20()
        {
            RunTest("09", 1);
        }

        private void RunTest(string integers, int expected)
        {
            CharacterCounter counter = GetInstance();
            int actual = counter.CountPossibleCharacters(integers);

            Assert.AreEqual(expected, actual, $"Expected {expected} but found {actual} for string '{integers}'");
        }
    }
}

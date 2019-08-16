using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Challenges.Week2;

namespace SamuraiDojo.Test.Week2
{
    [TestClass]
    [WrittenBy(Samurai.DUSTIN)]
    public class Dustin : BaseCharacterCounterTest
    {
        protected override ICharacterCounter GetInstance()
        {
            return new SamuraiDojo.Challenges.Week2.Dustin();
        }
    }
}

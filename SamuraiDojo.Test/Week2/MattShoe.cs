using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week2;

namespace SamuraiDojo.Test.Week2
{
    [TestClass]
    [WrittenBy(Samurai.MATT_SHOE)]
    public class MattShoe : BaseCharacterCounterTest
    {
        protected override CharacterCounter GetInstance()
        {
            return new SamuraiDojo.Battles.Week2.MattShoe();
        }
    }
}

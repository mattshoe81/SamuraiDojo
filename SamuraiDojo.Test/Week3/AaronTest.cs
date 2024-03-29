﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week3;

namespace SamuraiDojo.Test.Week3
{
    [TestClass]
    [WrittenBy(Samurai.Aaron)]
    public class AaronTests : CensusMaximusTest
    {
        protected override CensusMaximus GetInstance()
        {
            return new SamuraiDojo.Battles.Week3.Aaron();
        }
    }
}

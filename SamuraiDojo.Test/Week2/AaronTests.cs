﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Challenges.Week2;

namespace SamuraiDojo.Test.Week2
{
    [TestClass]
    [WrittenBy(Samurai.Aaron)]
    public class AaronTests : BaseCharacterCounterTest
    {
        protected override ICharacterCounter GetInstance()
        {
            return new SamuraiDojo.Challenges.Week2.Aaron();
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week#;

namespace SamuraiDojo.Test.Week#
{
    [TestClass]
    [WrittenBy(Samurai.YOU)]
    public class #YOU : BASE_TEST
    {
        protected override YOUR_BATTLE_CLASS GetInstance()
        {
            return new SamuraiDojo.Battles.Week#.YOU();
        }
    }
}

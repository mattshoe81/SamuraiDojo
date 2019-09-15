using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week6;

namespace SamuraiDojo.Test.Week6
{
    [TestClass]
    [WrittenBy(Samurai.JT)]
    public class JT : SuperfluousSansLoopTestBase
    {
        protected override SuperfluousSansLoop GetInstance()
        {
            return new SamuraiDojo.Battles.Week6.JT();
        }
    }
}

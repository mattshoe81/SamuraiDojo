using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week6;

namespace SamuraiDojo.Test.Week6
{
    [TestClass]
    [WrittenBy(Samurai.MATT_SHOE)]
    public class MattShoe : BASE_TEST
    {
        protected override SuperflousSansLoop GetInstance()
        {
            return new SamuraiDojo.Battles.Week6.MattShoe();
        }
    }
}

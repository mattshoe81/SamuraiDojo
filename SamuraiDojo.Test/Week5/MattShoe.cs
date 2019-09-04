using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week5;

namespace SamuraiDojo.Test.Week5
{
    [TestClass]
    [WrittenBy(Samurai.MATT_SHOE)]
    public class MattShoe : SnowflakeTestBase
    {
        protected override Snowflake GetInstance()
        {
            return new SamuraiDojo.Battles.Week5.MattShoe();
        }
    }
}

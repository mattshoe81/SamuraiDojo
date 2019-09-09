using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week5;

namespace SamuraiDojo.Test.Week5
{
    [TestClass]
    [WrittenBy(Samurai.DUSTIN)]
    public class Dustin : SnowflakeTestBase
    {
        protected override Snowflake GetInstance()
        {
            return new SamuraiDojo.Battles.Week5.Dustin();
        }
    }
}
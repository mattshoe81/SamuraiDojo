using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week4;

namespace SamuraiDojo.Test.Week4
{
    [TestClass]
    [WrittenBy(Samurai.JT)]
    public class JT : PalindromaniaTest
    {
        protected override Palindromania GetInstance()
        {
            return new SamuraiDojo.Battles.Week4.JT();
        }
    }
}
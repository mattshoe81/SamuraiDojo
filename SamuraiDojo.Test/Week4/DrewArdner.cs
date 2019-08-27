using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Battles.Week4;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Test.Week4
{
    [TestClass]
    [WrittenBy(Samurai.Drew)]
    public class DrewArdner : PalindromaniaTest
    {
        protected override Palindromania GetInstance()
        {
            return new Battles.Week4.DrewArdner();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week7;

namespace SamuraiDojo.Test.Week7
{
    [TestClass]
    [WrittenBy(Samurai.GOULD)]
    public class Gould : SinglyLinkedListAddOperationBaseTest
    {
        protected override SinglyLinkedList_Part1<int> GetInstance()
        {
            return new Gould<int>();
        }
    }
}

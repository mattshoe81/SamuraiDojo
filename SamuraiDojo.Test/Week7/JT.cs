using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week7;

namespace SamuraiDojo.Test.Week7
{
    [WrittenBy(Samurai.JT)]
    [TestClass]
    public class JT : SinglyLinkedListAddOperationBaseTest
    {
        protected override SinglyLinkedList_Part1<int> GetInstance()
        {
            return new SamuraiDojo.Battles.Week7.JT<int>();
        }
    }
}

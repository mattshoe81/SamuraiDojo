using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week7;

namespace SamuraiDojo.Test.Week7
{
    [WrittenBy(Samurai.MATT_SHOE)]
    [TestClass]
    public class MattShoe : SinglyLinkedListAddOperationBaseTest
    {
        protected override SinglyLinkedList_Part1<int> GetInstance()
        {
            return new SamuraiDojo.Battles.Week7.MattShoe<int>();
        }
    }
}

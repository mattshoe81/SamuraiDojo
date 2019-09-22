using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiDojo.Attributes;
using SamuraiDojo.Battles.Week8;

namespace SamuraiDojo.Test.Week8
{
    [WrittenBy(Samurai.MATT_SHOE)]
    [TestClass]
    public class MattShoe : SinglyLinkedList_Part2BaseTest
    {
        protected override SinglyLinkedList_Part2<int> GetInstance() => new SamuraiDojo.Battles.Week8.MattShoe<int>();
    }
}

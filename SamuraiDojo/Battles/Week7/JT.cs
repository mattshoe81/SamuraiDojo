using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;

namespace SamuraiDojo.Battles.Week7
{
    [TigerAward]
    [WrittenBy(Samurai.JT)]
    public class JT<T> : SinglyLinkedList_Part1<T>
    {
        private int nodeCount = 0;

        public override void Add(T item)
        {
            DojoListNode current = FrontNode;

            if (FrontNode == null) FrontNode = new DojoListNode() { Data = item };
            else
            {
                while (current.Next != null) current = current.Next;
                current.Next = new DojoListNode() { Data = item };
            }
            nodeCount++;
        }

        public override int Size()
        {
            return nodeCount;
        }
    }
}

using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;

namespace SamuraiDojo.Battles.Week7
{
    [MostElegant]
    [WrittenBy(Samurai.GOULD)]
    public class Gould<T> : SinglyLinkedList_Part1<T>
    {
        private int _count;

        public Gould()
        {
            _count = 0;
        }

        public override void Add(T item)
        {
            _ = FrontNode == null 
                ? FrontNode = BackNode = new DojoListNode { Data = item }
                : BackNode.Next = BackNode = new DojoListNode { Data = item };
        }

        public override int Size()
        {
            if (FrontNode != null)
            {
                _count++;
                FrontNode = FrontNode.Next;
                Size();
            }

            return _count;
        }
    }
}

using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week7
{
[WrittenBy(Samurai.MATT_SHOE)]
public class MattShoe<T> : SinglyLinkedList_Part1<T>
{
    private int size = 0;

    public override void Add(T item)
    {
        DojoListNode node = new DojoListNode();
        node.Data = item;

        if (FrontNode == null)
        {
            FrontNode = node;
            BackNode = node;
        }
        else
        {
            BackNode.Next = node;
            BackNode = node;
        }

        size++;
    }

    public override int Size() => size;
}
}

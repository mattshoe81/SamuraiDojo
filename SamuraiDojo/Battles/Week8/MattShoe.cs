using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week8
{
    [WrittenBy(Samurai.MATT_SHOE)]
    public class MattShoe<T> : SinglyLinkedList_Part2<T>
    {
        protected override int NumberOfNodes { get; set; }

        public override void AddFront(T item)
        {
            // TODO: ya thang

            //NumberOfNodes++
        }

        public override bool Remove(T item)
        {
            //TODO: don't forget to keep NumberOfNodes updated!

            return false;
        }
    }
}

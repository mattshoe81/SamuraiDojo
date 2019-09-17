using SamuraiDojo.DataStructures.LinkedList;

namespace SamuraiDojo.DataStructures.Stack
{
    public abstract class DojoStack<T>
    {
        private DojoLinkedList<T> linkedList;

        public DojoStack(DojoLinkedList<T> linkedList)
        {
            this.linkedList = linkedList;
        }

        public abstract void Push(T item);

        public abstract T Pop();

        public abstract bool Contains(T item);

        public abstract int Size();
    }
}

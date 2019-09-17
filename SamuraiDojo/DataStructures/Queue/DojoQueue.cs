using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.DataStructures.LinkedList;

namespace SamuraiDojo.DataStructures.Queue
{
    public abstract class DojoQueue<T>
    {
        protected DojoLinkedList<T> linkedList;

        public DojoQueue(DojoLinkedList<T> linkedList)
        {
            this.linkedList = linkedList;
        }

        public abstract void Enqueue(T item);

        public abstract void Dequeue(T item);

        public abstract void Contains(T item);

        public abstract int Size();
    }
}

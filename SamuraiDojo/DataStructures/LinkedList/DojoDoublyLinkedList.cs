using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.DataStructures.LinkedList
{
    public abstract class DojoDoublyLinkedList<T> : IDojoLinkedList<T>
    {
        /// <summary>
        /// A linked list is simply a chain of nodes, and each node holds some data of type T.
        /// 
        /// In a doubly linked list, each node also holds a reference to: 
        ///     - Next node in the list
        ///     - Previous node in the list
        ///     - Front node of the list
        ///     - Back of the list
        /// </summary>
        protected class Node
        {
            /// <summary>
            /// The data contained at this node of the linked list.
            /// </summary>
            public T Data { get; set; }

            /// <summary>
            /// A reference pointing to the node at the front of the list.
            /// </summary>
            public Node Front { get; set; }

            /// <summary>
            /// A reference pointing to the node at the end of the list.
            /// </summary>
            public Node Back { get; set; }

            /// <summary>
            /// A reference pointing to the next node in the list.
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// A reference pointing to the previous node in the list.
            /// </summary>
            public Node Previous { get; set; }

            public Node()
            {
                Data = default;
                Front = default;
                Back = default;
                Next = default;
                Previous = default;
            }
        }

        public abstract void Add(T item);

        public abstract void AddFront(T item);

        public abstract bool Contains(T item);

        public abstract void Remove(T item);

        public abstract int Size();
    }
}

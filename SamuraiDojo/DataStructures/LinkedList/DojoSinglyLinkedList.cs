using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.DataStructures.LinkedList
{
    public abstract class DojoSinglyLinkedList<T> : IDojoLinkedList<T>
    {
        /// <summary>
        /// A linked list is simply a chain of nodes. 
        /// 
        /// In a singly linked list, each node holds a reference to the next 
        /// node in the list, the node at the front of the list, the node 
        /// at the back of the list, and the data stored at that particular 
        /// node.
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

            public Node()
            {
                Data = default;
                Front = default;
                Back = default;
                Next = default;
            }
        }

        public abstract void Add(T item);

        public abstract void AddFront(T item);

        public abstract void Remove(T item);

        public abstract bool Contains(T item);

        public abstract int Size();
    }
}

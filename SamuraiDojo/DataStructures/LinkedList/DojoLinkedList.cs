using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.DataStructures.LinkedList
{
    public abstract class DojoLinkedList<T>
    {
        /// <summary>
        /// A reference pointing to the node at the front of the list.
        /// </summary>
        protected DojoListNode FrontNode { get; set; }

        /// <summary>
        /// A reference pointing to the node at the end of the list.
        /// </summary>
        protected DojoListNode BackNode { get; set; }

        /// <summary>
        /// Add an item to the end of the linked list.
        /// </summary>
        /// <param name="item"></param>
        public abstract void Add(T item);

        /// <summary>
        /// Add an item to the front of the linked list.
        /// </summary>
        /// <param name="item"></param>
        public abstract void AddFront(T item);

        /// <summary>
        /// Return true if the Equals() method returns true for any item in the list when compared 
        /// to the given item, and false otherwise.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public abstract bool Contains(T item);

        /// <summary>
        /// Remove the first occurence of the given item from the list. If the item is not in the list
        /// or could not be removed, returns false. Returns true otherwise.
        /// </summary>
        /// <param name="item"></param>
        public abstract bool Remove(T item);

        /// <summary>
        /// The number of items in this linked list.
        /// </summary>
        /// <returns></returns>
        public abstract int Size();

        /// <summary>
        /// A linked list is simply a chain of nodes, and each node holds some data of type T.
        /// 
        /// In a linked list, each node also holds a reference to: 
        ///     - Next node in the list
        ///     - Previous node in the list (if you have a DOUBLY linked list)
        /// </summary>
        protected class DojoListNode
        {
            public bool IsDummyNode { get; set; }
            /// <summary>
            /// The data contained at this node of the linked list.
            /// </summary>
            public T Data { get; set; }

            /// <summary>
            /// A reference pointing to the next node in the list.
            /// </summary>
            public DojoListNode Next { get; set; }

            /// <summary>
            /// A reference pointing to the previous node in the list.
            /// NOTE: 
            ///     This only applies to a doubly linked list.
            /// </summary>
            public DojoListNode Previous { get; set; }

            public DojoListNode()
            {
                IsDummyNode = false;
                Data = default;
                Next = default;
                Previous = default;
            }
        }

        public override string ToString()
        {
            string result = "[";
            DojoListNode current = FrontNode;
            while (current != null)
            {
                string separator = current.Next == null ? "" : ", ";
                if (!current.IsDummyNode)
                    result += $"{current.Data.ToString()}{separator}";

                current = current.Next;
            }
            result += "]";

            return result;
        }
    }
}

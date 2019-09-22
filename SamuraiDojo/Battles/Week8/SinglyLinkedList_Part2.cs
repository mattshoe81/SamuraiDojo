using System;
using SamuraiDojo.Attributes;
using SamuraiDojo.DataStructures.LinkedList;

namespace SamuraiDojo.Battles.Week8
{
    [Sensei(Samurai.MATT_SHOE)]
    [Battle("9/30/19", "Singly Linked List - Part 2", typeof(SinglyLinkedList_Part2<int>))]
    public abstract class SinglyLinkedList_Part2<T> : DojoLinkedList<T>
    {
        /*
            * For this week's puzzle, all you need to do is implement the Remove
            * operation and AddFront for a SINGLY linked list. The base class has
            * a Node class already defined, so you can use that for your nodes. 
            * Be sure to keep the Count property 
            * 
            * Constraints:
            *     - You cannot use any collection types to implement this.
            *     - You must use the Node class contained in the DojoSinglyLinkedList base class
            *     - You may use Dummy node(s) if you wish, that's just a matter of preference,
            *       but if you do, make sure you set the IsDummyNode property to true
            *     - The collection must be generic
            * 
            */

        protected abstract int NumberOfNodes { get; set; }

        public override int Size() => NumberOfNodes;

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

            NumberOfNodes++;
        }

        /// <summary>
        /// Remove the given item from the linked list if it exists.
        /// Returns true if the item was found and removed from the list. 
        /// Otherwise false.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public abstract override bool Remove(T item);

        /// <summary>
        /// Adds the given item to the front of the list.
        /// </summary>
        /// <param name="item"></param>
        public abstract override void AddFront(T item);

        public override bool Contains(T item) => throw new NotImplementedException();
    }
}

using System;
using SamuraiDojo.Attributes;
using SamuraiDojo.DataStructures.LinkedList;

namespace SamuraiDojo.Battles.Week7
{
    [Sensei(Samurai.MATT_SHOE)]
    [Battle("9/23/19", "Singly Linked List - Part 1", typeof(SinglyLinkedList_Part1<int>))]
    public abstract class SinglyLinkedList_Part1<T> : DojoLinkedList<T>
    {
        /*
         * For this week's puzzle, all you need to do is implement the Add
         * operation and the Size for a SINGLY linked list. The base class has
         * a Node class already defined, so you can use that for your nodes. 
         * Everything is set, all you need to do is put the logic for the Add 
         * operation.
         * 
         * Constraints:
         *     - You cannot use any collection types to implement this.
         *     - You must use the Node class contained in the DojoSinglyLinkedList base class
         *     - You may use Dummy node(s) if you wish, that's just a matter of preference,
         *       but if you do, make sure you set the IsDummyNode property to true
         *     - The collection must be generic
         * 
         */

        /// <summary>
        /// Add the given item to the end of the list.
        /// </summary>
        /// <param name="item"></param>
        public abstract override void Add(T item);

        /// <summary>
        /// Reports the number of items stored in the list.
        /// </summary>
        /// <returns></returns>
        public abstract override int Size();

        // Don't implement this (yet)
        public override void AddFront(T item)
        {
            throw new NotImplementedException();
        }

        // Don't implement this (yet)
        public override bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        // Don't implement this (yet)
        public override bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}

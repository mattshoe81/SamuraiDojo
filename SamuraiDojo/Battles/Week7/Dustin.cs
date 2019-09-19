using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week7
{
    [WrittenBy(Samurai.DUSTIN)]
    public class Dustin<T> : SinglyLinkedList_Part1<T>
    {
        public Dustin()
        {
            // Do some initialization if you need
        }

        public override void Add(T item)
        {
            DojoListNode newNode = new DojoListNode();
            newNode.Data = item;
            newNode.Next = null;

            if (base.FrontNode == null)
            {
                base.FrontNode = newNode;
                base.BackNode = newNode;
                return;
            }
            else
            {
                BackNode.Next = newNode;
                base.BackNode = newNode;
            }
        }

        public override int Size()
        {
            int counter = 0;
            DojoListNode currentNode = base.FrontNode;

            while (currentNode != null)
            {
                counter++;
                currentNode = currentNode.Next;
            }

            return counter;

        }
    }
}

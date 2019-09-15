using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Battles.Week7
{
    [WrittenBy(Samurai.MATT_SHOE)]
    public class MattShoe<T> : SinglyLinkedList_Part1<T>
    {        
        public MattShoe()
        {
            // Do some initialization if you need
        }

        public override void Add(T item)
        {
            // TODO: Link some list nodes and stuff

            //DojoListNode newNode = new DojoListNode();
            //base.Front = stuff and thingz
            //base.Back = other thingz and stuff
        }

        public override int Size()
        {
            return int.MaxValue;
        }
    }
}

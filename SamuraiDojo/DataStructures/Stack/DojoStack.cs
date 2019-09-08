using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.DataStructures.LinkedList;

namespace SamuraiDojo.DataStructures.Stack
{
    public abstract class DojoStack<T>
    {
        private IDojoLinkedList<T> linkedList;

        public DojoStack(IDojoLinkedList<T> linkedList)
        {
            this.linkedList = linkedList;
        }

        public abstract void Push(T item);

        public abstract T Pop();

        public abstract bool Contains(T item);
    }
}

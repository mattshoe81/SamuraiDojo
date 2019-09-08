﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.DataStructures.LinkedList;

namespace SamuraiDojo.DataStructures.Queue
{
    public abstract class DojoQueue<T>
    {
        protected IDojoLinkedList<T> linkedList;

        public DojoQueue(IDojoLinkedList<T> linkedList)
        {
            this.linkedList = linkedList;
        }

        public abstract void Enqueue(T item);

        public abstract void Dequeue(T item);

        public abstract void Contains(T item);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.DataStructures.LinkedList
{
    public class FrameworkLinkedList<T> : DojoLinkedList<T>
    {
        private LinkedList<T> representation;

        public FrameworkLinkedList()
        {
            representation = new LinkedList<T>();
        }

        public override void Add(T item) => representation.AddLast(item);

        public override void AddFront(T item) => representation.AddFirst(item);

        public override bool Contains(T item) => representation.Contains(item);

        public override bool Remove(T item) => representation.Remove(item);

        public override int Size() => representation.Count;

        public override string ToString()
        {
            string result = "[";

            foreach (T item in representation)
                result += $"{item.ToString()}, ";

            result = result.EndsWith(", ") ? result.Substring(0, result.Length - 2) : result;
            result += "]";

            return result;
        }
    }
}

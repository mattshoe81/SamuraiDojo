using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.DataStructures.LinkedList
{
    public interface IDojoLinkedList<T>
    {
        void Add(T item);

        void AddFront(T item);

        void Remove(T item);

        bool Contains(T item);
    }
}

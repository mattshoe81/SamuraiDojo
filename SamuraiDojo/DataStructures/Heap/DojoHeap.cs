using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.DataStructures.BinaryTree;

namespace SamuraiDojo.DataStructures.Heap
{
    public abstract class DojoHeap<T> where T : IComparable<T>
    {
        private DojoBinaryTree<T> binaryTree;

        public DojoHeap(DojoBinaryTree<T> binaryTree)
        {
            this.binaryTree = binaryTree;
        }

        public abstract T PeekTop();

        public abstract T RemoveTop();

        public abstract void Add(T item);

        public abstract void Contains(T item);
    }
}

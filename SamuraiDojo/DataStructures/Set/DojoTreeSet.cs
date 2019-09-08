using SamuraiDojo.DataStructures.BinaryTree;

namespace SamuraiDojo.DataStructures.Set
{
    public abstract class DojoTreeSet<T> : IDojoSet<T>
    {
        protected DojoBinaryTree<T> binaryTree;

        public DojoTreeSet(DojoBinaryTree<T> binaryTree)
        {
            this.binaryTree = binaryTree;
        }

        public abstract void Add(T item);
        public abstract bool Contains(T item);
        public abstract void Remove(T item);
    }
}

using SamuraiDojo.DataStructures.HashTable;

namespace SamuraiDojo.DataStructures.Set
{
    public abstract class DojoHashSet<T> : IDojoSet<T>
    {
        protected DojoHashTable<T> hashTable;

        public DojoHashSet(DojoHashTable<T> hashTable)
        {
            this.hashTable = hashTable;
        }

        public abstract void Add(T item);
        public abstract void Remove(T item);
        public abstract bool Contains(T item);
    }
}

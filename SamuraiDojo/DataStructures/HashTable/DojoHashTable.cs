using System.Collections.Generic;

namespace SamuraiDojo.DataStructures.HashTable
{
    public abstract class DojoHashTable<T>
    {
        protected List<T>[] hashTable;

        public DojoHashTable(int tableSize)
        {
            hashTable = new List<T>[tableSize];
        }

        public abstract void Add(T item);

        public abstract void Remove(T item);

        public abstract bool Contains(T item);
    }
}

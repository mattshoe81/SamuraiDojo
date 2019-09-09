using SamuraiDojo.DataStructures.HashTable;

namespace SamuraiDojo.DataStructures.Dictionary
{
    public abstract class DojoDictionary<K, V>
    {
        protected DojoHashTable<KVPair<K, V>> hashTable;

        public DojoDictionary(DojoHashTable<KVPair<K, V>> hashTable)
        {
            this.hashTable = hashTable;
        }

        public abstract void Put(K key, V value);

        public abstract void Remove(K key);

        public abstract bool Contains(K key);

        public abstract int KeyCount();

        public class KVPair<TKey, TValue>
        {
            TKey Key { get; set; }
            TValue Value { get; set; }

            public KVPair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public override bool Equals(object obj)
            {
                return Key.Equals(obj);
            }

            public override int GetHashCode()
            {
                return Key.GetHashCode();
            }
        }
    }
}

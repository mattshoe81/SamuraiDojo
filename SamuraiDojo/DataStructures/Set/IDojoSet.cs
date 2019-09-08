namespace SamuraiDojo.DataStructures.Set
{
    public interface IDojoSet<T>
    {
        void Add(T item);

        void Remove(T item);

        bool Contains(T item);
    }
}

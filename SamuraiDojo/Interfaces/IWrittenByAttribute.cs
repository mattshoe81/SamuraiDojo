namespace SamuraiDojo.Interfaces
{
    public interface IWrittenByAttribute
    {
        string Name { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}
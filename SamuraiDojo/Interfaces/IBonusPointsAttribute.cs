namespace SamuraiDojo.Interfaces
{
    public interface IBonusPointsAttribute
    {
        string Description { get; }
        string Name { get; }
        int Points { get; }
    }
}
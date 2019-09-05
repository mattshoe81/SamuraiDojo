namespace SamuraiDojo.IoC.Interfaces
{
    public interface IProjectSetup
    {
        void Initialize();

        bool HasBeenInitialized { get; set; }
    }
}

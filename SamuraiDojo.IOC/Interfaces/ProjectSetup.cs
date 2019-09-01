namespace SamuraiDojo.IoC.Interfaces
{
    public abstract class ProjectSetup
    {
        protected abstract void Initialize();

        protected abstract bool HasBeenInitialized { get; }

        public ProjectSetup()
        {
            SamuraiDojo.IoC.Setup.Initialize();

            if (!HasBeenInitialized)
                Initialize();

            Factory.Resolve();
        }
    }
}

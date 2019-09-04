using System.Configuration;

namespace SamuraiDojo.IoC
{
    public class DependentAssemblySettings : ConfigurationSection
    {
        public static DependentAssemblySettings Settings { get; } = ConfigurationManager.GetSection("DependentAssemblySettings") as DependentAssemblySettings;

        [ConfigurationProperty("assemblies", IsRequired = true)]
        public DependentAssemblyCollection Assemblies
        {
            get => this["assemblies"] as DependentAssemblyCollection; 
        }
    }
}

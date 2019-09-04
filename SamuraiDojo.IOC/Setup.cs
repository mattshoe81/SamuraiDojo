using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.IoC
{
    public static class Setup
    {
        private static bool initialized = false;

        public static void Initialize()
        {
            if (!initialized)
            {
                BindAssemblies();

                initialized = true;
            }
        }

        private static void BindAssemblies()
        {
            DependentAssemblySettings assemblySettings = (DependentAssemblySettings)ConfigurationManager.GetSection("DependentAssemblySettings");
            DependentAssemblyCollection assemblyCollection = assemblySettings.Assemblies;
            foreach (DependentAssemblyElement element in assemblyCollection)
                BindAssembly(element.Name);

            Factory.Resolve();
        }

        private static void BindAssembly(string name)
        {
            Assembly assembly = Assembly.Load(name);
            Type[] types = assembly.GetTypes().Where(type => typeof(IProjectSetup).IsAssignableFrom(type) && type != typeof(IProjectSetup)).ToArray();
            try
            {
                IProjectSetup setup = ((IProjectSetup)Activator.CreateInstance(types[0]));
                if (!setup.HasBeenInitialized)
                    setup.Initialize();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Assembly {assembly.GetName().Name} does not contain an implementation for IProjectSetup.");
            }
        }
    }

    public enum Project
    {
        Dojo,
        Test,
        Benchmarking,
        ScoreBoard,
        Scoring,
        Utility
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.IoC
{
    internal static class ReflectiveBinder
    {
        private static HashSet<string> loadedAssemblies;

        static ReflectiveBinder()
        {
            loadedAssemblies = new HashSet<string>();
        }

        /// <summary>
        /// Will load all assemblies referenced by the calling assembly, then look for
        /// a type that implements the IProjectSetup interface and executes its 
        /// Initialize() method. This allows all assemblies to keep their implementations 
        /// so as to only expose the interface to other assemblies.
        /// </summary>
        public static void Start(Assembly callingAssembly)
        {
            RecursiveAssemblyBinder(callingAssembly.GetName().FullName);
            Dojector.Resolve();
        }

        /// <summary>
        /// Will load up the specified assembly, and if it has an implementation of the IProjectSetup 
        /// interface, it will invoke its Initialize() method. Then it will load all assemblies 
        /// referenced by that assembly and do this all over again, recursively. This will ensure that
        /// every assembly and all of its dependencies are loaded and checked.
        /// </summary>
        /// <param name="name"></param>
        private static void RecursiveAssemblyBinder(string name)
        {
            Assembly assembly = Assembly.Load(name);

            InvokeSetupIfPossible(assembly);

            // Remember this assembly so we don't load it again!
            loadedAssemblies.Add(name);

            // Recursively load all assemblies referenced by this assembly and try to bind them
            AssemblyName[] referencedAssemblies = assembly.GetReferencedAssemblies();
            if (referencedAssemblies.Length > 0)
                BindAssemblies(assembly.GetReferencedAssemblies());
        }

        private static void InvokeSetupIfPossible(Assembly assembly)
        {
            Type[] types = assembly.GetTypes().Where(type => typeof(IProjectSetup).IsAssignableFrom(type) && type != typeof(IProjectSetup)).ToArray();
            try
            {
                if (types.Length > 0)
                {
                    IProjectSetup setup = ((IProjectSetup)Activator.CreateInstance(types[0]));
                    if (!setup.HasBeenInitialized)
                        setup.Initialize();
                }
                else
                {
                    Debug.WriteLine($"Assembly '{assembly.GetName().Name}' does not have in implementation of IProjectSetup, so no dependencies could be bound in this project.");
                }
            }
            catch { }
        }

        private static void BindAssemblies(AssemblyName[] assemblies)
        {
            foreach (AssemblyName element in assemblies)
            {
                try
                {
                    if (!loadedAssemblies.Contains(element.FullName))
                        RecursiveAssemblyBinder(element.FullName);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Unable to load assembly:{Environment.NewLine}{ex.ToString()}");
                }
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

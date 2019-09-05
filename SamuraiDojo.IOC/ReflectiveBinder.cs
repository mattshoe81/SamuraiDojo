using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using SamuraiDojo.IoC.Interfaces;

namespace SamuraiDojo.IoC
{
    public static class ReflectiveBinder
    {
        private static bool initialized;
        private static HashSet<string> loadedAssemblies;

        static ReflectiveBinder()
        {
            initialized = false;
            loadedAssemblies = new HashSet<string>();
        }

        /// <summary>
        /// Will load all assemblies referenced by the calling assembly, then look for
        /// a type that implements the IProjectSetup interface and executes its 
        /// Initialize() method. This allows all assemblies to keep their implementations 
        /// so as to only expose the interface to other assemblies.
        /// </summary>
        public static void Start()
        {
            if (!initialized)
            {
                Assembly callingAssembly = Assembly.GetCallingAssembly();
                AssemblyName[] assemblies = callingAssembly.GetReferencedAssemblies();
                BindAssembly(callingAssembly.GetName().FullName);
                BindAssemblies(assemblies);

                Factory.Resolve();

                initialized = true;
            }
        }

        private static void BindAssemblies(AssemblyName[] assemblies)
        {
            foreach (AssemblyName element in assemblies)
            {
                try
                {
                    if (!loadedAssemblies.Contains(element.FullName))
                        BindAssembly(element.FullName);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Unable to load assembly:{Environment.NewLine}{ex.ToString()}");
                }
            }
        }

        private static void BindAssembly(string name)
        {
            Assembly assembly = Assembly.Load(name);

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
            catch (Exception ex)
            {
                //throw new InvalidOperationException($"Assembly {assembly.GetName().Name} does not contain an implementation for IProjectSetup.");
            }

            loadedAssemblies.Add(name);
            AssemblyName[] referencedAssemblies = assembly.GetReferencedAssemblies();
            if (referencedAssemblies.Length > 0)
                BindAssemblies(assembly.GetReferencedAssemblies());
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

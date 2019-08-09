using System;
using System.Reflection;

namespace SamuraiDojo.Spar
{
    internal class TestRunner
    {
        public void Run()
        {
            Assembly assem1 = Assembly.Load(AssemblyName.GetAssemblyName("SamuraiDojo.Test"));
            Type[] types = assem1.GetTypes();
            foreach (Type type in types)
            {
                object instance = Activator.CreateInstance(type);

                if (type.IsPublic && !type.IsAbstract)
                {
                    MemberInfo[] methods = type.GetMethods();
                    foreach (MemberInfo method in methods)
                    {
                        if (method.ReflectedType.IsPublic)
                            method
                    }
                }
            }
        }
    }
}

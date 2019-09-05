using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.IoC.DependencyManagement;
using SamuraiDojo.IoC.DependencyManagement.Interfaces;

namespace SamuraiDojo.IoC
{
    public class Dojector
    {
        private static readonly IMultiBindCollection multiBindMap;
        private static readonly IDependencyRepository dependencies;
        private static readonly IDependencyInjector injector;
        private static readonly IDependencyBinder binder;
        
        static Dojector()
        {
            multiBindMap = InternalFactory.Get<IMultiBindCollection>();
            dependencies = InternalFactory.Get<IDependencyRepository>();
            injector = InternalFactory.Get<IDependencyInjector>();
            binder = InternalFactory.Get<IDependencyBinder>();
        }

        /// <summary>
        /// Will load all assemblies referenced by the calling assembly, then look for
        /// a type that implements the IProjectSetup interface and executes its 
        /// Initialize() method. This allows all assemblies to keep their implementations 
        /// internal so as to only expose the interface to other assemblies.
        /// </summary>
        public static void BindAssembliesReflectively()
        {
            Assembly callingAssembly = Assembly.GetCallingAssembly();
            ReflectiveBinder.Start(callingAssembly);
        }

        /// <summary>
        /// Binds the interface supplied as the generic parameter to the specified 
        /// concrete type. The optional parameter of the method allows you to specify whether
        /// the binding should use the Singleton pattern or create a new instance on each
        /// retrieval. By default, a new instance of the concrete type will be created on 
        /// every retrieval.
        /// </summary>
        /// <typeparam name="T">Interface to which an implementation will be bound</typeparam>
        /// <param name="type">Concrete type used for instantiation</param>
        public static void Bind<T>(Type concreteType, BindingConfig config = BindingConfig.Default)
        {
            ValidateBinding<T>("Dojector.Bind", concreteType);
            binder.Bind<T>(concreteType, config);
        }

        /// <summary>
        /// Allows you to bind multiple concrete types to a single interface by specifying a
        /// unique string key for each implementation. The interface type is supplied as the
        /// generic parameter. The concrete type must be accompanied by a unique key by which
        /// it will be retrieved for instantiation. The optional parameter allows you to specify
        /// whether the concrete type will be bound as a Singleton or not. By default, the concrete
        /// type will be newly instantiated on every retrieval unless you specify otherwise.
        /// </summary>
        /// <typeparam name="T">The interface to which an implementation will be bound</typeparam>
        /// <param name="key">The unique identifier for an implementation</param>
        /// <param name="concreteType">The concrete type being bound to the interface</param>
        public static void MultiBind<T>(string key, Type concreteType, BindingConfig config = BindingConfig.Default)
        {
            ValidateBinding<T>("Factory.MultiBind", concreteType);
            multiBindMap.Bind<T>(key, concreteType, config);
        }

        /// <summary>
        /// Removes the binding associated with an interface. The optional parameter allows you
        /// to specify whether to debind only singleton bindings or debind only transient bindings.
        /// The default behavior is to remove all singleton AND transient bindings. This method
        /// does NOT affect multibindings.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        public static void Debind<T>(BindingConfig config = BindingConfig.Default)
        {
            binder.Debind<T>(config);
        }

        /// <summary>
        /// Removes the binding associated with an interface. The optional parameter allows you
        /// to specify whether to debind only singleton bindings or debind only transient bindings.
        /// The default behavior is to remove all singleton AND transient bindings. This method
        /// does NOT affect multibindings.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        public static void Debind(Type interfaceType, BindingConfig config = BindingConfig.Default)
        {
            binder.Debind(interfaceType, config);
        }

        /// <summary>
        /// Resolve the dependencies for registerd bindings. This MUST be performed after
        /// all bindings have been made.
        /// </summary>
        public static void Resolve()
        {
            binder.Resolve();
        }

        /// <summary>
        /// Clears all bindings and dependencies.
        /// </summary>
        public static void Reset()
        {
            dependencies.Transient.Clear();
            dependencies.Singleton.Clear();
            multiBindMap.Clear();
        }

        private static void ValidateBinding<T>(string methodName, Type type)
        {
            AssertInterface<T>(methodName);
            AssertImplementation<T>(methodName, type);
        }

        private static void AssertInterface<T>(string methodName)
        {
            // Interface type must be abstract or interface
            if (!(typeof(T).IsInterface || typeof(T).IsAbstract))
                throw new InvalidCastException($"Generic type parameter for {methodName} must be an interface.");
        }

        private static void AssertImplementation<T>(string methodName, Type concreteType)
        {
            if (concreteType == null)
                throw new InvalidOperationException($"The concrete type must not be nul.l");

            if (concreteType.IsInterface)
                throw new InvalidCastException($"Concrete type for {methodName} must NOT be an interface.");

            bool implementsInterface = typeof(T).IsAssignableFrom(concreteType);
            if (!implementsInterface)
                throw new InvalidCastException($"Concrete type does not implement the specified interface.");
        }
    }
}

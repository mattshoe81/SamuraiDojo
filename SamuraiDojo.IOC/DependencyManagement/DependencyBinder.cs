using System;
using System.Collections.Generic;
using SamuraiDojo.IoC.DependencyManagement.Interfaces;

namespace SamuraiDojo.IoC.DependencyManagement
{
    internal class DependencyBinder : IDependencyBinder
    {
        private IDependencyRepository dependencies;
        private IDependencyInjector dependencyInjector;

        private IDictionary<Type, Type> cachedSingletons;

        public DependencyBinder(IDependencyRepository dependencies, IDependencyInjector dependencyInjector)
        {
            this.dependencies = dependencies;
            this.dependencyInjector = dependencyInjector;

            cachedSingletons = new Dictionary<Type, Type>();
        }

        public void Bind<T>(Type concreteType, BindingConfig config = BindingConfig.Default)
        {
            switch (config)
            {
                case BindingConfig.Singleton:
                    BindSingleton<T>(concreteType);
                    break;
                case BindingConfig.Transient:
                    BindTransient<T>(concreteType);
                    break;
                default:
                    BindDefault<T>(concreteType);
                    break;
            }
        }

        public void Debind<T>(BindingConfig config = BindingConfig.Default)
        {
            Type interfaceType = typeof(T);
            Debind(interfaceType, config);
        }

        public void Debind(Type interfaceType, BindingConfig config = BindingConfig.Default)
        {
            switch (config)
            {
                case BindingConfig.Singleton:
                    dependencies.Singleton.Remove(interfaceType);
                    break;
                case BindingConfig.Transient:
                    dependencies.Transient.Remove(interfaceType);
                    break;
                default:
                    dependencies.Singleton.Remove(interfaceType);
                    dependencies.Transient.Remove(interfaceType);
                    break;
            }
        }

        /// <summary>
        /// Algorithm:
        /// Dump the singleton cache into a queue. Then iterate the contents of the queue, trying to resolve
        /// each dependency. If you can't resolve, put it into the stack. On the next iteration, do the same
        /// logic with the stack, but put the unresolved dependencies into the queue. Continue this until
        /// both queues are empty, or until you've looped x times without resolving anything, meaning there
        /// is probably a circular dependency, so give up and throw exception.
        /// 
        /// This essentially allows you to keep looking through the dependencies forwards, then backwards,
        /// over and over again, until you're able to resolve all dependencies or until you run into a 
        /// circular dependency. I am only 40% sure this will never get stuck in a loop if there is no 
        /// circular dependency. There is probably a way to prove one way or the other.
        /// 
        /// TODO: Prove, mathematically, the viability of this algorithm. In other words, prove whether
        ///       this algorithm could be stuck in a loop without circular dependencies.
        /// </summary>
        public void Resolve()
        {
            Queue<KeyValuePair<Type, Type>> queue = new Queue<KeyValuePair<Type, Type>>(cachedSingletons);
            Stack<KeyValuePair<Type, Type>> stack = new Stack<KeyValuePair<Type, Type>>();
            cachedSingletons.Clear();

            int maxLoops = 10;
            int loopCount = 0;
            int size = queue.Count;
            while (loopCount <= maxLoops && (stack.Count > 0 || queue.Count > 0))
            {
                if (queue.Count > 0)
                    ResolveContentsOfQueue(queue, stack);
                else
                    ResolveContentsOfStack(queue, stack);

                if (stack.Count == size || queue.Count == size)
                    loopCount++;
                else
                    loopCount = 0;

                size = queue.Count > 0 ? queue.Count : stack.Count;

                CheckMaxLoop(loopCount, maxLoops);
            }
        }

        private void CheckMaxLoop(int loopCount, int maxLoops)
        {
            if (loopCount == maxLoops)
                throw new InvalidOperationException("A potential circular dependency has been detected. If you are certain no circular dependencies exist, shuffle the order of your dependency bindings and try again.");
        }

        private void ResolveContentsOfQueue(Queue<KeyValuePair<Type, Type>> queue, Stack<KeyValuePair<Type, Type>> stack)
        {
            while (queue.Count > 0)
            {
                KeyValuePair<Type, Type> pair = queue.Dequeue();
                object instance = dependencyInjector.ResolveConcrete(pair.Value);

                if (instance == default)
                    stack.Push(pair);
                else
                    dependencies.Singleton[pair.Key] = instance;
            }
        }

        private void ResolveContentsOfStack(Queue<KeyValuePair<Type, Type>> queue, Stack<KeyValuePair<Type, Type>> stack)
        {
            while (stack.Count > 0)
            {
                KeyValuePair<Type, Type> pair = stack.Pop();
                object instance = dependencyInjector.ResolveConcrete(pair.Value);

                if (instance == default)
                    queue.Enqueue(pair);
                else
                    dependencies.Singleton[pair.Key] = instance;
            }
        }

        private void BindDefault<T>(Type concreteType)
        {
            Type interfaceType = typeof(T);

            if (dependencies.Singleton.ContainsKey(interfaceType))
                BindSingleton<T>(concreteType);
            else if (dependencies.Transient.ContainsKey(interfaceType))
                BindTransient<T>(concreteType);
            else
                dependencies.Transient.Add(interfaceType, concreteType);
        }

        private void BindSingleton<T>(Type concreteType)
        {
            Type interfaceType = typeof(T);
            cachedSingletons.Add(interfaceType, concreteType);

            //// If it is already bound, remove the binding to allow rebind
            //if (dependencies.Singleton.ContainsKey(interfaceType))
            //    dependencies.Singleton.Remove(interfaceType);

            //T singleton = (T)dependencyInjector.ResolveConcrete(concreteType);

            //if (dependencies.Singleton.ContainsKey(interfaceType))
            //    dependencies.Singleton[interfaceType] = singleton;
            //else
            //    dependencies.Singleton.Add(interfaceType, singleton);
        }

        private void BindTransient<T>(Type concreteType)
        {
            Type interfaceType = typeof(T);

            if (dependencies.Transient.ContainsKey(interfaceType))
                dependencies.Transient[interfaceType] = concreteType;
            else
                dependencies.Transient.Add(interfaceType, concreteType);
        }
    }
}

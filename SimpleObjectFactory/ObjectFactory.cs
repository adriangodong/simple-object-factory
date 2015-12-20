using System;
using System.Collections.Generic;

namespace SimpleObjectFactory
{
    public class ObjectFactory
    {

        private readonly Dictionary<Type, IObjectCreator> registry = new Dictionary<Type, IObjectCreator>();

        public void RegisterType<TService, TImplementation>() where TImplementation : TService
        {
            if (!typeof(TService).IsAssignableFrom(typeof(TImplementation)))
            {
                throw new ArgumentException($"{typeof(TService).Name} is not assignable from {typeof(TImplementation).Name}");
            }

            if (registry.ContainsKey(typeof(TService)))
            {
                throw new ArgumentException($"{typeof(TService).Name} has been added previously");
            }

            registry.Add(typeof(TService), new SingletonObjectCreator<TImplementation>());
        }

        public void RegisterType<TImplementation>()
        {
            RegisterType<TImplementation, TImplementation>();
        }

        public void RegisterType<TImplementation>(TImplementation implementation)
        {
            registry.Add(typeof(TImplementation), new PrebuiltObjectCreator(implementation));
        }

        public TContract GetInstance<TContract>() where TContract : class
        {
            return GetInstance(typeof(TContract)) as TContract;
        }

        public object GetInstance(Type type)
        {
            if (registry.ContainsKey(type))
            {
                return registry[type].GetService(this);
            }

            return null;
        }

    }
}

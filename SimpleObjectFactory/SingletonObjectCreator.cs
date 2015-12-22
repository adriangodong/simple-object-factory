using System.Reflection;

namespace SimpleObjectFactory
{
    internal class SingletonObjectCreator<T> : IObjectCreator
    {
        private object instance;

        public object GetService(ObjectFactory factory)
        {
            if (instance != null)
                return instance;

            var implementationType = typeof(T);

            foreach (var constructor in implementationType.GetTypeInfo().DeclaredConstructors)
            {
                if (constructor.IsPublic)
                {
                    var parameterInfos = constructor.GetParameters();
                    var parameters = new object[parameterInfos.Length];
                    var parametersCompleted = true;

                    for (int i = 0; i < parameterInfos.Length; i++)
                    {
                        var parameterInfo = parameterInfos[i];
                        var parameter = factory.GetInstance(parameterInfo.ParameterType);
                        if (parameter == null)
                        {
                            parametersCompleted = false;
                            break;
                        }

                        parameters[i] = parameter;
                    }

                    if (parametersCompleted)
                    {
                        instance = constructor.Invoke(parameters);
                        return instance;
                    }
                }
            }

            return null;
        }
    }
}
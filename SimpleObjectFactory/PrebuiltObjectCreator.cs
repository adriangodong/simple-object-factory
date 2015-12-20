namespace SimpleObjectFactory
{
    internal class PrebuiltObjectCreator : IObjectCreator
    {
        private readonly object instance;

        public PrebuiltObjectCreator(object instance)
        {
            this.instance = instance;
        }

        public object GetService(ObjectFactory factory)
        {
            return instance;
        }
    }
}
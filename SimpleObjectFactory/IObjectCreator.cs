namespace SimpleObjectFactory
{
    public interface IObjectCreator
    {
        object GetService(ObjectFactory factory);
    }
}

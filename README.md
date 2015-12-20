# simple-object-factory

Simple Object Factory supports Dependency Injection pattern in .NET. SOF simplifies creation of types with chained dependencies. SOF is reflection-based constructor-injection library.

Usage:

    // Class definitions:

    public class Foo
    {
    }

    public class Bar
    {
        public Bar(Foo foo)
        {
        }
    }

    public class Baz
    {
        public Baz(Bar bar)
        {
        }
    }

    // Instantiate ObjectFactory and register types

    ObjectFactory objectFactory = new ObjectFactory();
    objectFactory.RegisterType<Foo>();
    objectFactory.RegisterType<Bar>();
    objectFactory.RegisterType<Baz>();

    // Automatically instantiate registered types

    Foo foo = objectFactory.GetInstance<Foo>();
    Bar bar = objectFactory.GetInstance<Bar>();
    Baz baz = objectFactory.GetInstance<Baz>();

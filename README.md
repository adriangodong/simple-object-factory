# simple-object-factory

Simple Object Factory supports Dependency Injection pattern in .NET. SOF simplifies creation of types with chained dependencies. SOF is reflection-based constructor-injection library.

[![Build status](https://ci.appveyor.com/api/projects/status/93khbhtsx6jolc11?svg=true)](https://ci.appveyor.com/project/adriangodong/simple-object-factory)
[![NuGet](https://img.shields.io/nuget/v/SimpleObjectFactory.svg)](https://www.nuget.org/packages/SimpleObjectFactory/)

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

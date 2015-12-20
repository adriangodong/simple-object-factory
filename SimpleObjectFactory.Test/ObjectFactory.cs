using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleObjectFactory.Test
{
    [TestClass]
    public class ObjectFactory
    {

        [TestMethod]
        public void ImplementationOnly()
        {

            var serviceFactory = new SimpleObjectFactory.ObjectFactory();
            serviceFactory.RegisterType<Implementation>();

            var service = serviceFactory.GetInstance<Implementation>();
            Assert.IsNotNull(service);

        }

        [TestMethod]
        public void CorrectDerivative()
        {

            var serviceFactory = new SimpleObjectFactory.ObjectFactory();
            serviceFactory.RegisterType<IInterface, Implementation>();

            var service = serviceFactory.GetInstance<IInterface>();
            Assert.IsNotNull(service);

        }

        [TestMethod]
        public void ParameterlessCtor()
        {

            var serviceFactory = new SimpleObjectFactory.ObjectFactory();
            serviceFactory.RegisterType<ClassWithParameterlessCtor, ClassWithParameterlessCtor>();

            var service = serviceFactory.GetInstance<ClassWithParameterlessCtor>();
            Assert.IsNotNull(service);

        }

        [TestMethod]
        public void ParameterizedCtor()
        {

            var serviceFactory = new SimpleObjectFactory.ObjectFactory();
            serviceFactory.RegisterType<ClassWithParameterlessCtor, ClassWithParameterlessCtor>();
            serviceFactory.RegisterType<ClassWithParameterizedCtor, ClassWithParameterizedCtor>();

            var service = serviceFactory.GetInstance<ClassWithParameterizedCtor>();
            Assert.IsNotNull(service);
            Assert.IsNotNull(service.Parent);

        }

        [TestMethod]
        public void UndeclaredParameterCtor()
        {

            var serviceFactory = new SimpleObjectFactory.ObjectFactory();
            serviceFactory.RegisterType<ClassWithParameterizedCtor, ClassWithParameterizedCtor>();

            var service = serviceFactory.GetInstance<ClassWithParameterizedCtor>();
            Assert.IsNull(service);

        }

        [TestMethod]
        public void StaticInstance()
        {
            var expected = new Implementation();
            var serviceFactory = new SimpleObjectFactory.ObjectFactory();
            serviceFactory.RegisterType(expected);

            var actual = serviceFactory.GetInstance<Implementation>();

            Assert.IsNotNull(actual);
            Assert.AreSame(expected, actual);
        }

        private interface IInterface
        {
        }

        private class Implementation : IInterface
        {
        }

        private class ClassWithParameterlessCtor
        {
        }

        private class ClassWithParameterizedCtor
        {
            public ClassWithParameterlessCtor Parent { get; set; }

            public ClassWithParameterizedCtor(ClassWithParameterlessCtor parent)
            {
                Parent = parent;
            }
        }

    }
}

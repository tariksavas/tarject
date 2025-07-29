using System;
using System.Reflection;
using NUnit.Framework;
using Tarject.Editor.TestFramework.UnitTest;
using Tarject.Runtime.Utility;

namespace Tarject.Tests.Editor.Utility
{
    public class InheritanceInjectionTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.Bind<FirstSampleClass>();
            Container.Bind<SecondSampleClass>();
            Container.Bind<DerivedClass>();
        }

        [Test]
        public void Inject_With_Base_Type()
        {
            DerivedClass derivedClass = Container.Resolve<DerivedClass>();

            Assert.IsNotNull(derivedClass);
            Assert.IsNotNull(derivedClass?.firstSampleClass);
            Assert.IsNotNull(derivedClass?.secondSampleClass);
        }

        [Test]
        public void Get_Fields_With_Base_Type_Fields()
        {
            Type type = typeof(DerivedClass);
            FieldInfo[] fields = type.GetCachedFields();

            Assert.IsTrue(fields[0].FieldType == typeof(FirstSampleClass));
            Assert.IsTrue(fields[1].FieldType == typeof(SecondSampleClass));
        }
        
        private class FirstSampleClass
        {

        }
        
        private class SecondSampleClass
        {

        }

        private class BaseClass
        {
            public readonly FirstSampleClass firstSampleClass;

            public BaseClass(FirstSampleClass firstSampleClass)
            {
                this.firstSampleClass = firstSampleClass;
            }
        }

        private class DerivedClass : BaseClass
        {
            public readonly SecondSampleClass secondSampleClass;

            public DerivedClass(FirstSampleClass firstSampleClass, SecondSampleClass secondSampleClass) : base(firstSampleClass)
            {
                this.secondSampleClass = secondSampleClass;
            }
        }
    }
}
using Tarject.Runtime.Core.Context;
using NUnit.Framework;

namespace Tarject.Editor.TestFramework.UnitTest
{
    public abstract class TarjectUnitTestFixture
    {
        protected DIContainer Container { get; set; } = new DIContainer();

        [SetUp]
        protected void SetupFixture()
        {
            Setup();
            InjectToConstructors();
        }

        protected abstract void Setup();

        private void InjectToConstructors()
        {
            Container.CompleteBindings();
        }
    }
}
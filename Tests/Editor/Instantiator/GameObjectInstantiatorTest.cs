using NUnit.Framework;
using Tarject.Editor.TestFramework.UnitTest;
using Tarject.Runtime.Core.Instantiator;
using UnityEngine;

namespace Tarject.Tests.Editor.Instantiator
{
    public class GameObjectInstantiatorTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.Bind<GameObjectInstantiator>().ToInterface<IInstantiator>();
        }
        
        private T CreatePrefab<T>() where T : Component
        {
            GameObject go = new GameObject(typeof(T).Name);
            return go.AddComponent<T>();
        }
        
        [Test]
        public void Instantiate_Without_Params()
        {
            IInstantiator instantiator = Container.Resolve<IInstantiator>();
            Assert.IsNotNull(instantiator);
            
            Sample prefab = CreatePrefab<Sample>();
            Sample instance  = instantiator.Create(prefab, container: Container);
            
            Assert.IsNotNull(instance);
        }
        
        public class Sample : MonoBehaviour { }
    }
}
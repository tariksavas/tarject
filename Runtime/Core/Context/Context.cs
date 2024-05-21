using System;
using Tarject.Runtime.Core.Installer;
using Tarject.Runtime.Core.Interfaces;
using Tarject.Runtime.StructuralDefinitions;
using UnityEngine;
using IDisposable = Tarject.Runtime.Core.Interfaces.IDisposable;

namespace Tarject.Runtime.Core.Context
{
    public abstract class Context : MonoBehaviour
    {
        [SerializeField]
        private OptimizedList<GameObjectInstaller> _gameObjectInstallers = new OptimizedList<GameObjectInstaller>();

        private DIContainer _container;

        protected DIContainer Container => _container;

        private OptimizedList<IInitializable> initializables;
        private OptimizedList<IUpdatable> updatables;
        private OptimizedList<IFixedUpdatable> fixedUpdatables;
        private OptimizedList<ILateUpdatable> lateUpdatables;
        private OptimizedList<IDisposable> disposables;

        protected virtual void Awake()
        {
            _container = new DIContainer(this);

            InstallMonoInstallers();
        }

        private void Start()
        {
            InjectConstructorsAfterBindings();

            GetTriggerableInterfaces();

            initializables.ForEach(x=> x.Initialize());
        }

        public abstract T Resolve<T>(Type type = null, string id = "") where T : class;

        private void InstallMonoInstallers()
        {
            for (int index = 0; index < _gameObjectInstallers.Count; index++)
            {
                _gameObjectInstallers[index].Install(Container);
            }
        }
        
        private void InjectConstructorsAfterBindings()
        {
            Container.InjectConstructorsAfterBindings(this);
        }

        private void GetTriggerableInterfaces()
        {
            initializables = Container.GetTriggerableInterfaces<IInitializable>();
            updatables = Container.GetTriggerableInterfaces<IUpdatable>();
            fixedUpdatables = Container.GetTriggerableInterfaces<IFixedUpdatable>();
            lateUpdatables = Container.GetTriggerableInterfaces<ILateUpdatable>();
            disposables = Container.GetTriggerableInterfaces<IDisposable>();
        }

        private void Update()
        {
            updatables.ForEach(x => x.Update());
        }

        private void FixedUpdate()
        {
            fixedUpdatables.ForEach(x => x.FixedUpdate());
        }

        private void LateUpdate()
        {
            lateUpdatables.ForEach (x => x.LateUpdate());
        }

        protected virtual void OnDestroy()
        {
            disposables.ForEach(x => x.Dispose());
        }
    }
}
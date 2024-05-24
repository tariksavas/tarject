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

        private readonly DIContainer _container = new DIContainer();

        protected DIContainer Container => _container;

        private OptimizedList<IInitializable> _initializables;
        private OptimizedList<IUpdatable> _updatables;
        private OptimizedList<IFixedUpdatable> _fixedUpdatables;
        private OptimizedList<ILateUpdatable> _lateUpdatables;
        private OptimizedList<IDisposable> _disposables;

        protected virtual void Awake()
        {
            _container.AddContainerContextRegistry(this);

            InstallMonoInstallers();
        }

        private void Start()
        {
            InjectConstructorsAfterBindings();

            GetTriggerableInterfaces();

            _initializables.ForEach(x => x.Initialize());
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
            _initializables = Container.GetObjectsOfType<IInitializable>();
            _updatables = Container.GetObjectsOfType<IUpdatable>();
            _fixedUpdatables = Container.GetObjectsOfType<IFixedUpdatable>();
            _lateUpdatables = Container.GetObjectsOfType<ILateUpdatable>();
            _disposables = Container.GetObjectsOfType<IDisposable>();
        }

        private void Update()
        {
            _updatables.ForEach(x => x.Update());
        }

        private void FixedUpdate()
        {
            _fixedUpdatables.ForEach(x => x.FixedUpdate());
        }

        private void LateUpdate()
        {
            _lateUpdatables.ForEach(x => x.LateUpdate());
        }

        protected virtual void OnDestroy()
        {
            _disposables.ForEach(x => x.Dispose());
        }
    }
}
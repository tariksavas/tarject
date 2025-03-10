using Tarject.Runtime.Core.Installer;
using Tarject.Runtime.Core.Interfaces;
using Tarject.Runtime.StructuralDefinitions;
using UnityEngine;

namespace Tarject.Runtime.Core.Context
{
    public abstract class Context : MonoBehaviour
    {
        [SerializeField]
        private OptimizedList<GameObjectInstaller> _gameObjectInstallers = new OptimizedList<GameObjectInstaller>();

        private readonly DIContainer _container = new DIContainer();

        internal DIContainer Container => _container;

        private OptimizedList<IInitializable> _initializables;
        private OptimizedList<IUpdatable> _updatables;
        private OptimizedList<IFixedUpdatable> _fixedUpdatables;
        private OptimizedList<ILateUpdatable> _lateUpdatables;
        private OptimizedList<ILateDisposable> _lateDisposables;

        protected virtual void Awake()
        {
            SetParentContainer();

            InstallMonoInstallers();

            CompleteBindings();

            GetTriggerableInterfaces();

            _initializables.ForEach(x => x.Initialize());

        }

        protected abstract void SetParentContainer();

        private void InstallMonoInstallers()
        {
            for (int index = 0; index < _gameObjectInstallers.Count; index++)
            {
                _gameObjectInstallers[index].Install(Container);
            }
        }

        private void CompleteBindings()
        {
            _container.CompleteBindings();
        }

        private void GetTriggerableInterfaces()
        {
            _initializables = Container.GetObjectsOfType<IInitializable>();
            _updatables = Container.GetObjectsOfType<IUpdatable>();
            _fixedUpdatables = Container.GetObjectsOfType<IFixedUpdatable>();
            _lateUpdatables = Container.GetObjectsOfType<ILateUpdatable>();
            _lateDisposables = Container.GetObjectsOfType<ILateDisposable>();
        }

        private void Update()
        {
            _updatables?.ForEach(x => x.Update());
        }

        private void FixedUpdate()
        {
            _fixedUpdatables?.ForEach(x => x.FixedUpdate());
        }

        private void LateUpdate()
        {
            _lateUpdatables?.ForEach(x => x.LateUpdate());
        }

        protected virtual void OnDestroy()
        {
            _lateDisposables?.ForEach(x => x.LateDispose());
        }
    }
}

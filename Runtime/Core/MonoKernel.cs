using Tarject.Runtime.Core.Interfaces;
using Tarject.Runtime.StructuralDefinitions;
using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core
{
    [DefaultExecutionOrder(-100)]
    public class MonoKernel : MonoBehaviour
    {
        private OptimizedList<IInitializable> _initializables = new OptimizedList<IInitializable>();

        private OptimizedList<IDisposable> _disposables = new OptimizedList<IDisposable>();

        private void Awake()
        {
            FindInitializables();
            FindDisposables();
            AssignConstructDependencies();
        }

        private void FindInitializables()
        {
            OptimizedList<object> initializables = DiContainer.iObjects.FindAll(x => x is IInitializable);
            for (int index = 0; index < initializables.Count; index++)
            {
                _initializables.Add(initializables[index] as IInitializable);
            }
        }

        private void FindDisposables()
        {
            OptimizedList<object> disposables = DiContainer.iObjects.FindAll(x => x is IDisposable);
            for (int index = 0; index < disposables.Count; index++)
            {
                _disposables.Add(disposables[index] as IDisposable);
            }
        }

        private void AssignConstructDependencies()
        {
            DiContainer.objects.ForEach(x => x.AssignInjectionToMethods("Construct"));
        }

        private void Start()
        {
            for (int i = 0; i < _initializables.Count; i++)
            {
                _initializables[i].Initialize();
            }
        }

        private void OnDestroy()
        {
            for (int index = 0; index < _disposables.Count; index++)
            {
                _disposables[index].Dispose();
            }
        }
    }
}
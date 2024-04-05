using System;
using UnityEngine;

namespace Tarject.Runtime.Core
{
    [DefaultExecutionOrder(-200)]
    public sealed class ProjectInstaller : MonoBehaviour
    {
        private void Awake()
        {
            Install();
            CreateKernel();
        }

        private void Install()
        {

        }

        private void CreateKernel()
        {
            GameObject kernel = new GameObject("MonoKernel", typeof(MonoKernel));
            kernel.transform.parent = transform;
            DontDestroyOnLoad(transform);
        }

        private void Install<T>() where T : DiInstaller
        {
            T installer = (T)Activator.CreateInstance(typeof(T));
            installer.Install();
        }
    }
}
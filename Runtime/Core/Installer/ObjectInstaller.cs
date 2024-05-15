using System;
using Tarject.Runtime.Core.Context;

namespace Tarject.Runtime.Core.Installer
{
    public abstract class ObjectInstaller : ObjectInstallerBase
    {
        public static void CreateAndInstall<T>(DIContainer container) where T : ObjectInstaller
        {
            T installer = (T)Activator.CreateInstance(typeof(T));
            installer.Install(container);
        }
    }

    public abstract class ObjectInstaller<T> : ObjectInstallerBase where T : ObjectInstaller<T>
    {
        public static void CreateAndInstall(DIContainer container)
        {
            T installer = (T)Activator.CreateInstance(typeof(T));
            installer.Install(container);
        }
    }
}
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Factory;
using UnityEngine;

namespace Tarject.Runtime.Core.Instantiator
{
    public interface IInstantiator
    {
        T Create<T>(T prefab, Transform parent = null, bool preserveWorldScale = false, DIContainer container = null)
            where T : Component;

        T Create<T, TParam>(T prefab, TParam param, Transform parent = null, bool preserveWorldScale = false, DIContainer container = null)
            where T : Component, IFactorable<TParam>;

        T Create<T, TParam1, TParam2>(T prefab, TParam1 param1, TParam2 param2, Transform parent = null, bool preserveWorldScale = false, DIContainer container = null)
            where T : Component, IFactorable<TParam1, TParam2>;

        T Create<T, TParam1, TParam2, TParam3>(T prefab, TParam1 param1, TParam2 param2, TParam3 param3, Transform parent = null, bool preserveWorldScale = false, DIContainer container = null)
            where T : Component, IFactorable<TParam1, TParam2, TParam3>;

        T Create<T, TParam1, TParam2, TParam3, TParam4>(T prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, Transform parent = null, bool preserveWorldScale = false, DIContainer container = null)
            where T : Component, IFactorable<TParam1, TParam2, TParam3, TParam4>;

        T Create<T, TParam1, TParam2, TParam3, TParam4, TParam5>(T prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, Transform parent = null, bool preserveWorldScale = false, DIContainer container = null)
            where T : Component, IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5>;
    }
}
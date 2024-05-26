using Tarject.Runtime.Core.Context;

namespace Tarject.Runtime.Core.Factory
{
    public class Factory
    {
        protected DIContainer _container;

        public void SetContainer(DIContainer container)
        {
            _container = container;
        }
    }
}
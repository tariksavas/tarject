namespace Tarject.Runtime.Core.Factory
{
    public interface IFactory
    {
    }

    public interface IFactory<TParam1> : IFactory
    {
        void InitializeFactory(TParam1 param);
    }

    public interface IFactory<TParam1, TParam2> : IFactory
    {
        void InitializeFactory(TParam1 param1, TParam2 param2);
    }

    public interface IFactory<TParam1, TParam2, TParam3> : IFactory
    {
        void InitializeFactory(TParam1 imageKey, TParam2 param2, TParam3 param3);
    }

    public interface IFactory<TParam1, TParam2, TParam3, TParam4> : IFactory
    {
        void InitializeFactory(TParam1 param1, TParam2 param2, TParam3 value, TParam4 param4);
    }

    public interface IFactory<TParam1, TParam2, TParam3, TParam4, TParam5> : IFactory
    {
        void InitializeFactory(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);
    }
}
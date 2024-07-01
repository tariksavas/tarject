namespace Tarject.Runtime.Core.Factory
{
    public interface IFactorable
    {
    }

    public interface IFactorable<TParam1> : IFactorable
    {
        void InitializeFactory(TParam1 param);
    }

    public interface IFactorable<TParam1, TParam2> : IFactorable
    {
        void InitializeFactory(TParam1 param1, TParam2 param2);
    }

    public interface IFactorable<TParam1, TParam2, TParam3> : IFactorable
    {
        void InitializeFactory(TParam1 imageKey, TParam2 param2, TParam3 param3);
    }

    public interface IFactorable<TParam1, TParam2, TParam3, TParam4> : IFactorable
    {
        void InitializeFactory(TParam1 param1, TParam2 param2, TParam3 value, TParam4 param4);
    }

    public interface IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5> : IFactorable
    {
        void InitializeFactory(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);
    }
}
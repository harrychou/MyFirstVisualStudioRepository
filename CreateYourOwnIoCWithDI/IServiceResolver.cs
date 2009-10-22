using System;

namespace CreateYourOwnIoCWithDI
{
    public interface IServiceResolver
    {
        void Register<TFrom, TTo>();
        T Resolve<T>();
        object Resolve(Type fromType);
    }
}
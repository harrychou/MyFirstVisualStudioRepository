using System;

namespace CreateYourOwnIoCWithDI
{
    public interface IDependencyInjector
    {
        T GetInjectedInstance<T>() where T : class;
        object GetInjectedInstance(Type fromType);
        IServiceResolver ServiceResolver { get; set; }
    }
}
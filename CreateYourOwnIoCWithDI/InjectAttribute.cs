using System;

namespace CreateYourOwnIoCWithDI
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Constructor)]
    public class InjectAttribute : Attribute
    {

    }
}
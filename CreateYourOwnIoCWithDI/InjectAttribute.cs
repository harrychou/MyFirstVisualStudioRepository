/*******************************
 * Code adopted from Paul's post 
 * http://adventuresdotnet.blogspot.com/2009/09/creating-your-own-ioc-container-part-2.html
 * *******************************/
using System;

namespace CreateYourOwnIoCWithDI
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Constructor)]
    public class InjectAttribute : Attribute
    {

    }
}
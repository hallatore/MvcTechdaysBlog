using System;

namespace MvcTechdaysBlog.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AllowAnonymousAttribute : Attribute
    {
    }
}
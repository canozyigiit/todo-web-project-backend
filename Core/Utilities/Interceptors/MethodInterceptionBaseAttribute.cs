using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]//classlara veya metotlara eklenebilir, birden fazla eklenebilir ve inherit edildiğinde çalışsın
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }//Öncelik gerekirse

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}

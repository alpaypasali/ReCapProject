
using Castle.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //class attribute oku
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            //method attribute oku
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            //ve onlari listele
            classAttributes.AddRange(methodAttributes);
            //eger loglama eklersek kullanicaz
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            //onlarin calisma sirasini oncelik degerine gore belirle
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}

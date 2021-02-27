﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interception
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
           List<MethodInterceptionBaseAttribute> classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
           var methodAttributes =
               type.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
           if (methodAttributes != null) classAttributes.AddRange(methodAttributes);

           // ReSharper disable once CoVariantArrayConversion
           return classAttributes.OrderByDescending(x => x.Priority).ToArray();
        }
    }
}
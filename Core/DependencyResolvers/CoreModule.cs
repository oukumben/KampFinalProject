﻿using System.Diagnostics;
using Core.Cross_Cutting_Concerns.Caching;
using Core.Cross_Cutting_Concerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheAdapter>();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
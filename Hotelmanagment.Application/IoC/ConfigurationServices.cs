﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Hotelmanagment.Application.IoC
{
    public static class ConfigurationServices
    {
        public static IServiceCollection ServiceConfigurationFromApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
           return services;
        }
    }
}

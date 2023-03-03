using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Presistance.Context;
using HotelManagement.Presistance.Repositories;
using Hotelmanagment.Application.Contract.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagement.Presistance.IoC
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ServicesConfigurationFrompresistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DefaultContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HotelmanagemntDb"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}

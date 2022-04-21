using System;
using System.Collections.Generic;
using System.Text;
using Context.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Context
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(o => o.UseMySQL(configuration.GetConnectionString("Default")));
            return services;
        }
    }
}

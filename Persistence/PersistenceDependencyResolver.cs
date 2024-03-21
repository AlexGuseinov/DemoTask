using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceDependencyResolver
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseNpgsql(configuration["DbConnectionString"]);
            });
            return services;
        }
    }
}

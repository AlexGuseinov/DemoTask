using Application.Abstracts.Infrastructure.Adapters.Movies;
using Application.Abstracts.Infrastructure.Adapters.Users;
using Infrastructure.Adapters.Movies.ImdbAdapter;
using Infrastructure.Adapters.Users.DummyAdapter;
using Infrastructure.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureDependencyResolver
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            IConfiguration? configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IMovieAdapter, ImdbMovieAdapter>();
            services.AddScoped<IUserAdapter, DummyUserAdapter>();
            services.Configure<IMDBConfig>(configuration.GetSection("IMDBSource"));
            services.Configure<OnlineMovieDBConfig>(configuration.GetSection("OnlineMovieDBSource"));
            return services;
        }
    }
}

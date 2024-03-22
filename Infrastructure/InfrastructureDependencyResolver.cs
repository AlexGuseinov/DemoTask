using Application.Abstracts.Infrastructure.Adapters.Movies;
using Infrastructure.Adapters.Movies.ImdbAdapter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureDependencyResolver
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMovieAdapter, ImdbMovieAdapter>();
            return services;
        }
    }
}

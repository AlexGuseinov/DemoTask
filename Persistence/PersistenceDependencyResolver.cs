using Application.Abstracts.Persistence.Repositories.Movies;
using Application.Abstracts.Persistence.Repositories.Watchlists;
using Application.Abstracts.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.Movies;
using Persistence.Services;
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

            services.AddScoped<IWatchlistWriteRepository, WatchlistWriteRepository>();
            services.AddScoped<IWatchlistReadRepository, WatchlistReadRepository>();
            services.AddScoped<IMovieReadRepository, MovieReadRepository>();
            services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();
            services.AddScoped<IMovieService, MovieManager>();
            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Application.CrossCuttingConcerns.Exceptions.Extensions;
using Quartz;
using Application.Features.Watchlists.Jobs;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;

namespace Application
{
    public static class ApplicationDependencyResolver
    {
        public static IServiceCollection AddApplicationDepdendencies(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(option => option.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddHttpClient();
            services.AddExceptionHandler();

            services.AddQuartz(opt =>
            {
                opt.UseMicrosoftDependencyInjectionJobFactory();

                var jobKey = JobKey.Create(nameof(UnWatchedMovieOfferJob));

                opt.AddJob<UnWatchedMovieOfferJob>(jobKey)
                   .AddTrigger(trigger => trigger.ForJob(jobKey).WithCronSchedule(configuration["CronSchedule"]));
            });

            services.AddQuartzHostedService();

            return services;
        }
    }
}

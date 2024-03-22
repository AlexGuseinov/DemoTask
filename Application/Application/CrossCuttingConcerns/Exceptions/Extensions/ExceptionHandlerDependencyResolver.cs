using Application.CrossCuttingConcerns.Exceptions.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CrossCuttingConcerns.Exceptions.Extensions
{
    public static class ExceptionHandlerDependencyResolver
    {
        public static IServiceCollection AddExceptionHandler(this IServiceCollection services)
        {
            services.AddSingleton<ExceptionHandler, HttpExceptionHandler>();
            return services;
        }
    }
}

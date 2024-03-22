﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Application.CrossCuttingConcerns.Exceptions.Extensions;

namespace Application
{
    public static class ApplicationDependencyResolver
    {
        public static IServiceCollection AddApplicationDepdendencies(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(option => option.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddHttpClient();
            services.AddExceptionHandler();
            return services;
        }
    }
}

using MailService.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Register Mail service
        /// </summary>
        /// <param name="implementation">Mail service use by default Gmail SMTP implementation</param>
        /// <returns></returns>
        public static IServiceCollection AddMailService(this IServiceCollection services, IConfiguration configuration ,Type implementation = null)
        {

            if (implementation is null)
                services.AddScoped(typeof(IMailService), typeof(GmailMailService));
            else
                services.AddScoped(typeof(IMailService), implementation);

            services.Configure<SMTPConfig>(configuration.GetSection("SMTPConfig"));

            return services;
        }
    }
}

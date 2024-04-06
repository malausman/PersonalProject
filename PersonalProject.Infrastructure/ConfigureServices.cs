using PersonalProject.Domain.IRepositories;
using PersonalProject.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureLMSData(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
           // services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
            //services.AddScoped<IUserRepository, NMemoryUserRepository>();
            //services.AddScoped<IUserRefreshTokenRepository, NMemoryUserRefreshTokenRepository>();
            return services;
        }
    }
}

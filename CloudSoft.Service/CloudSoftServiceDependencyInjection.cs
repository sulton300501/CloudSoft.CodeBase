using CloudSoft.Service.Abstractions.AuthServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Service
{
    public static class CloudSoftServiceDependencyInjection
    {
        public static IServiceCollection AddCloudSoftServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}

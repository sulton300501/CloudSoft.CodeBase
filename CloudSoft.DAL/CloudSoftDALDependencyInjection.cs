using CloudSoft.DAL.Persistance;
using CloudSoft.Service.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.DAL
{
    public static class CloudSoftDALDependencyInjection
    {
        public static IServiceCollection AddCloudSoftDALDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<IApplicationDbContext, CloudSoftDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Db"));
            });
            
            return services;
        }
    }
}

using CloudSoft.DAL.Persistance;
using CloudSoft.DAL;
using CloudSoft.Data.Entities.Auth;
using CloudSoft.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CloudSoft.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddCloudSoftServiceDependencyInjection();
            builder.Services.AddCloudSoftDALDependencyInjection(builder.Configuration);

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CloudSoftDbContext>()
                .AddDefaultTokenProviders();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

         
          
            app.Run();
        }
    }
}

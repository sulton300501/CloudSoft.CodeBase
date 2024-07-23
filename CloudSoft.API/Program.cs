
using CloudSoft.DAL;
using CloudSoft.DAL.Persistance;
using CloudSoft.Data.Entities;
using CloudSoft.Service;
using Microsoft.AspNetCore.Identity;

namespace CloudSoft.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddCloudSoftServiceDependencyInjection();
            builder.Services.AddCloudSoftDALDependencyInjection(builder.Configuration);

            builder.Services.AddIdentity<Admin, IdentityRole<long>>()
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

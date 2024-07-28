using CloudSoft.Data.Entities;
using CloudSoft.Data.Entities.Auth;
using CloudSoft.Service.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.DAL.Persistance
{
    public class CloudSoftDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
    {
        public CloudSoftDbContext(DbContextOptions<CloudSoftDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }


      

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "ADMIN", ConcurrencyStamp = "1", NormalizedName = "ADMIN"  },
                new IdentityRole() { Name = "USER", ConcurrencyStamp = "2", NormalizedName = "USER" }
              
            );
        }





        public DbSet<Admin> Admins { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ExtensionsName> Extensions { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }
        public DbSet<ProjectInfo> Projects { get; set; }
        public DbSet<TeamMemeber> TeamMemebers { get; set; }

        public DbSet<UserApp> UserApps { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectInfo>(e =>
            {
                e.Property(p => p.Description)
                    .HasColumnType("text");


                e.HasMany(p => p.Extensions)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TeamMemeber>(e =>
            {

                e.Property(p => p.Description)
                    .HasColumnType("text");
            });

            modelBuilder.Entity<ExtensionsName>(e =>
            {

                e.Property(p => p.Description)
                    .HasColumnType("text");
            });

            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);


        }

        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }




    





    }
}

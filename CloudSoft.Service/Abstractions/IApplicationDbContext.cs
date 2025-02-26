﻿using CloudSoft.Data.Entities;
using CloudSoft.Data.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace CloudSoft.Service.Abstractions
{
    public interface IApplicationDbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ExtensionsName> Extensions { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }
        public DbSet<ProjectInfo> Projects { get; set; }
        public DbSet<TeamMemeber> TeamMemebers { get; set; }
        public DbSet<UserApp> UserApps { get; set; }

        ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default!);

    }
}

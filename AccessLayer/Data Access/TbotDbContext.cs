using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Models;
using Models.Claims;
using Models.UserModels;


namespace Data_Access
{
    public class TbotDbContext : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<Role> Roles {  get; set; }
        
        public DbSet<UserAction> UserActions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Videos> Videos { get; set; }


        public TbotDbContext(DbContextOptions<TbotDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<Users>());

            new CategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Category>());

            new RoleEntityTypeConfiguration().Configure(modelBuilder.Entity<Role>());

            new UserActionEntityTypeConfiguration().Configure(modelBuilder.Entity<UserAction>());

            new UserInfoEntityTypeConfiguration().Configure(modelBuilder.Entity<UserInfo>());

            new VideoEntityTypeConfiguration().Configure(modelBuilder.Entity<Videos>());
        }


    }
}

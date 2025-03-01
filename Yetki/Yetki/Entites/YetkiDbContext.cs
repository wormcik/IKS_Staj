﻿using System;
using Microsoft.EntityFrameworkCore;
namespace Yetki.Entites
{
	public class YetkiDbContext : DbContext
	{
        private IConfiguration configuration;


        public YetkiDbContext(DbContextOptions contextOptions, IConfiguration configuration) : base(contextOptions)
        {
            this.configuration = configuration;
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserRoleType> UserRoleType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var defaultSchema = configuration.GetConnectionString("DefaultSchema");
            if (defaultSchema != null && defaultSchema != "public")
            {
                modelBuilder.HasDefaultSchema(configuration.GetConnectionString("DefaultSchema"));
            }
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            _ = configurationBuilder.Properties<DateTime>().HaveColumnType("datetime");
        }

    }
}


using System;
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

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserRoleType> UserRoleTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserID);

            modelBuilder.Entity<UserType>().HasKey(u => u.TypeId);

            modelBuilder.Entity<UserRole>().HasKey(u => u.UserRoleId);

            modelBuilder.Entity<UserRoleType>().HasKey(u => u.UserRoleTypeId);

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


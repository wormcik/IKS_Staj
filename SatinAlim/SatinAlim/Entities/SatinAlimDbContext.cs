using Microsoft.EntityFrameworkCore;

namespace SatinAlim.Entities
{
    public class SatinAlimDbContext : DbContext
    {
        private IConfiguration configuration;

        public SatinAlimDbContext(DbContextOptions contextOptions,  IConfiguration configuration) : base (contextOptions)
        {
            this.configuration = configuration;
        }

        public DbSet<Personel> Personel { get; set; }
        public DbSet<SatinAlmaBirim> SatinAlmaBirim { get; set; }
        public DbSet<SatinAlmaBirimOnayci> SatinAlmaBirimOnayci { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasCollation("my_collation", locale: "tr-TR-u-ks-level2", provider: "icu", deterministic: false); //custom collation
      
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

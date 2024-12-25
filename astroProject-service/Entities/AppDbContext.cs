using Microsoft.EntityFrameworkCore;

namespace astroProject_service.Entities
{
    public class AppDbContext : DbContext
    {
        private IConfiguration configuration;

        public AppDbContext(
            DbContextOptions dbContextOptions,
            IConfiguration configuration
            ) : base(dbContextOptions)
        {
            this.configuration = configuration;
        }


        public DbSet<ZodiacSignStream> ZodiacSignStream { get; set; }
        public DbSet<TarotCard> TarotCard { get; set; }
    
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

            _ = configurationBuilder.Properties<DateTime>().HaveColumnType("timestamp");
        }
    }
}

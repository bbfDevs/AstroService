using astroProject_service.Entities.EnumModels;
using astroProject_service.Entities.UserModels;
using astroProject_service.Enums;
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
        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<MembershipEntity> Membership { get; set; }
        public DbSet<RelationshipEntity> Relationship { get; set; }
        public DbSet<ZodiacEntity> Zodiac { get; set; }
        public DbSet<LifeAspectEntity> LifeAspect { get; set; }
        public DbSet<TarotCardEntity> TarotCard { get; set; }

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

            modelBuilder.Entity<MembershipEntity>().ReflectToDatabase<MembershipTypeEnum, MembershipEntity>();
            modelBuilder.Entity<RelationshipEntity>().ReflectToDatabase<RelationshipTypeEnum, RelationshipEntity>();
            modelBuilder.Entity<ZodiacEntity>().ReflectToDatabase<ZodiacEnum, ZodiacEntity>();
            modelBuilder.Entity<LifeAspectEntity>().ReflectToDatabase<LifeAspectEnum, LifeAspectEntity>();
            modelBuilder.Entity<TarotCardEntity>().ReflectToDatabase<TarotCardEnum, TarotCardEntity>();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            _ = configurationBuilder.Properties<DateTime>().HaveColumnType("timestamp");
        }
    }
}

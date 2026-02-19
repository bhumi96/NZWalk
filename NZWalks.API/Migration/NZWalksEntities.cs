using Microsoft.EntityFrameworkCore;
using NZWalks.API.Domain_Model;

namespace NZWalks.API.Migrations
{
    public class NZWalksEntities : DbContext
    {
        public NZWalksEntities(DbContextOptions options) : base(options) { }
       
        public DbSet<Region> Region {  get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Walks> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    DifficultyId = Guid.Parse("7a2de582-caf2-46fa-a3c2-ff395c2078a7"),
                    Name = "Easy",
                },
                new Difficulty()
                {
                    DifficultyId = Guid.Parse("e4cb354e-15b2-4061-b7b0-7581f0c74926"),
                    Name = "Medium",
                },
                new Difficulty()
                {
                    DifficultyId = Guid.Parse("6372c198-ccb1-47f5-b420-9111a98c5cf8"),
                    Name = "Hard",
                },
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }

    }
}

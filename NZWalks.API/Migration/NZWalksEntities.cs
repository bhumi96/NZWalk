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


    }
}

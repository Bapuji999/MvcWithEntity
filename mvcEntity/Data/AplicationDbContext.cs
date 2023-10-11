using Microsoft.EntityFrameworkCore;
using mvcEntity.Models;

namespace mvcEntity.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base (options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
                (
                    new Category { CategoryId = 1, Name = "Action", DisplayOrder = 1},
                    new Category { CategoryId = 2, Name = "SiFi", DisplayOrder = 2 },
                    new Category { CategoryId = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}

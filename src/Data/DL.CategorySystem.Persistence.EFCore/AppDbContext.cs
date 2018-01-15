using DL.CategorySystem.Domain.Categories;
using DL.CategorySystem.Persistence.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DL.CategorySystem.Persistence.EFCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Self-contained type configuration
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}

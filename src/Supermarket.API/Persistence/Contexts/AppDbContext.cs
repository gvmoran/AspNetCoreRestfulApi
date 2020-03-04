using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Product { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Category");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData(
                new Category {Id = 100, Name = "Frutas y Vegetales"},
                new Category {Id = 101, Name = "Diario"}
            );

            builder.Entity<Product>().ToTable("Product");
            



        }
    }
}
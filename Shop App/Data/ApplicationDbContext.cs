using Microsoft.EntityFrameworkCore;
using Shop_App.Models;

namespace Shop_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Blog> blogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company { Id=1,Name="Nike"},
                new Company { Id=2,Name="Addidas"}
                );
            modelBuilder.Entity<Category>().HasData(
                new Company { Id=1,Name="Sports"},
                new Company { Id=2,Name="Life Style"}
                );
        }
    }
}

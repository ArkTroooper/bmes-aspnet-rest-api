using BmesRestApi.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace BmesRestApi.Database
{
    public class BmesDbContext : DbContext
    {
        public BmesDbContext(DbContextOptions<BmesDbContext> options) : base(options){}
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

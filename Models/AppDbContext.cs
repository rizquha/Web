using Microsoft.EntityFrameworkCore;

namespace Task_Web_Product.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Items> items {get;set;}
        public DbSet<Carts> carts {get;set;}
        public AppDbContext (DbContextOptions options):base(options)
        {
            
        }
    }
}
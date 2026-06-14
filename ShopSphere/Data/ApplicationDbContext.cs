using Microsoft.EntityFrameworkCore;
using ShopSphere.Models;

namespace ShopSphere.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) :base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }  
        public DbSet<Category> Category { get; set; }
        public DbSet<User> users { get; set; } 
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CarItem> CarItems { get; set; }    
        public DbSet<Order> Orders { get; set; }
    }

}

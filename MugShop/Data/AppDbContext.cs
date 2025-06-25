using Microsoft.EntityFrameworkCore;
using MugShop.Data.Entities;

namespace MugShop.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Mug> Mugs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

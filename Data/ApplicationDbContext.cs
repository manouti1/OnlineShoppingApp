using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp.Models;
using System.Collections.Generic;

namespace OnlineShoppingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}

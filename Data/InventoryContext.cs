using Inventory.Model;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data
{

    public class InventoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-GNVRFJ8;Initial Catalog=Inventory;Integrated Security=True;Pooling=False");
        }
    }

}



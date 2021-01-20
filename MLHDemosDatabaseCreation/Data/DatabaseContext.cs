using Microsoft.EntityFrameworkCore;
using MLHDemosDatabaseCreation.Model;

namespace MLHDemosDatabaseCreation.Data
{
    public class DatabaseContext : DbContext
    {
        // These represent tables in a Database

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        // This is for local database,
        // Other options are SQL databases... but i am not risking you do that on one ;)

        // This instantiates the use of a Local SQLlite Database for our testing
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }
}
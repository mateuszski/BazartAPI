using Bazart.Models;
using Microsoft.EntityFrameworkCore;


namespace Bazart.DataAccess.Data
{
    public class BazartDbContext : DbContext
    {
        public BazartDbContext(DbContextOptions<BazartDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}

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
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .OwnsOne((u => u.ShoppingCart));
            modelBuilder.Entity<User>()
                .HasOne(p => p.ShoppingCart)
                .WithOne(b => b.User)
                .HasForeignKey<ShoppingCart>(s => s.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Events)
                .WithMany(e => e.Users);

            //modelBuilder
                //.Entity<Event>()
            //.HasOptional(e => e.State)
                //.WithMany()
                //.WillCascadeOnDelete(false);
        }

    }
}

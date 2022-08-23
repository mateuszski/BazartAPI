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
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts{ get; set; }
        //public DbSet<OwnedEvent> OwnedEvents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasMany(p => p.Orders)
            //    .WithOne(b => b.User)
            //    .HasForeignKey<Order>(s => s.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Events)
                .WithMany(e => e.Users);

            modelBuilder.Entity<Event>()
                .HasOne(o => o.Owner)
                .WithMany(u => u.OwnedEvents)
                .HasForeignKey(u => u.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(o => new{o.OrderId,o.ProductId});

            modelBuilder.Entity<OrderProduct>()
                .HasOne(o => o.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Order>()
            //    .HasMany(o => o.Products)
            //    .WithMany(p => p.Orders)
            //    .UsingEntity(j => j.ToTable("OrderProduct"))
            //    .

            //modelBuilder.Entity<OrderProduct>()
            //    .HasOne(op => op.OrderId)
            //    .WithMany(o => o.Order);

        }

    }
}

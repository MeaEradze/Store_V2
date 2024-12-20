using Microsoft.EntityFrameworkCore;
using Store.Domain;

namespace Store_V2.Infastructure
{
    public class Store_V2_DbContext : DbContext
    {
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }

        public Store_V2_DbContext(DbContextOptions<Store_V2_DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure CartItems
            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
                entity.HasOne(e => e.Cart)
                      .WithMany(c => c.CartItems)
                      .HasForeignKey(e => e.CartId)
                      .IsRequired();
                entity.HasOne(e => e.Product)
                      .WithMany(p => p.CartItems)
                      .HasForeignKey(e => e.ProductId)
                      .IsRequired();
            });

            // Configure Carts
            modelBuilder.Entity<Carts>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.LastEditedDate).IsRequired();
                entity.HasOne(e => e.Customer)
                      .WithMany(c => c.Carts)
                      .HasForeignKey(e => e.CustomerId)
                      .IsRequired();
            });

            // Configure Customers
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Address).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            });

            // Configure OrderItems
            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.CartItem)
                      .WithMany()
                      .HasForeignKey(e => e.CartItemId);
                entity.HasOne(e => e.Order)
                      .WithMany(o => o.OrderItems)
                      .HasForeignKey(e => e.OrderId);
            });

            // Configure Orders
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.HasOne(e => e.Customer)
                      .WithMany(c => c.Orders)
                      .HasForeignKey(e => e.CustomerId);
            });

            // Configure Products
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProductTitle).HasMaxLength(100).IsRequired();
                entity.Property(e => e.ProductDescription).HasMaxLength(500);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.ProductStock).IsRequired();
            });
        }
    }
}

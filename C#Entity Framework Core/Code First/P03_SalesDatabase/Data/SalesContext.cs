
using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }
        public SalesContext(DbContextOptions<SalesContext> options)
            :base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=Sales;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.ProductId);

                entity.Property(p => p.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(50);

                entity.Property(p => p.Quantity)
                      .IsRequired();

                entity.Property(p => p.Price)
                      .IsRequired();

                entity.Property(p => p.Description)
                      .HasDefaultValue("No description");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(x => x.CustomerId);

                entity.Property(c => c.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(100);

                entity.Property(c => c.Email)
                      .IsRequired()
                      .IsUnicode(false)
                      .HasMaxLength(80);

                entity.Property(p => p.CreditCardNumber)
                      .IsRequired()
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(x => x.StoreId);

                entity.Property(s => s.Name)
                      .IsRequired()
                      .IsUnicode()
                      .HasMaxLength(80);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(x => x.SaleId);

                entity.Property(s => s.Date)
                      .IsRequired()
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(s => s.Product)
                      .WithMany(p => p.Sales)
                      .HasForeignKey(s => s.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Customer)
                      .WithMany(c => c.Sales)
                      .HasForeignKey(s => s.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Store)
                      .WithMany(s => s.Sales)
                      .HasForeignKey(s => s.StoreId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}

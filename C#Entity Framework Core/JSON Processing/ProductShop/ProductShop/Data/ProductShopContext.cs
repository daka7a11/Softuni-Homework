﻿using Microsoft.EntityFrameworkCore;
using ProductShop.Models;

namespace ProductShop.Data
{


    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }
        public ProductShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=ProductShop;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(p => p.Buyer)
                      .WithMany(u => u.ProductsBought)
                      .HasForeignKey(p => p.BuyerId);

                entity.HasOne(p => p.Seller)
                      .WithMany(u => u.ProductsSold)
                      .HasForeignKey(p => p.SellerId);
            });

            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.CategoryId, x.ProductId });

                entity.HasOne(cp => cp.Category)
                      .WithMany(c => c.CategoryProducts)
                      .HasForeignKey(cp => cp.CategoryId);

                entity.HasOne(cp => cp.Product)
                      .WithMany(p => p.CategoryProducts)
                      .HasForeignKey(cp => cp.ProductId);
            });
        }
    }
}
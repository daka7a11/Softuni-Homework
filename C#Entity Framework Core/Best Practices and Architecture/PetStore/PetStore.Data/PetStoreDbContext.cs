using Microsoft.EntityFrameworkCore;
using PetStore.Common;
using PetStore.Data.Configurations;
using PetStore.Models;

namespace PetStore.Data
{
    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext()
        {
        }
        public PetStoreDbContext(DbContextOptions<PetStoreDbContext> options)
            :base(options)
        {
        }

        virtual public DbSet<Breed> Breeds { get; set; }
        virtual public DbSet<Client> Clients { get; set; }
        virtual public DbSet<Food> Foods { get; set; }
        virtual public DbSet<Order> Orders { get; set; }
        virtual public DbSet<Pet> Pets { get; set; }
        virtual public DbSet<Toy> Toys { get; set; }
        virtual public DbSet<ClientProduct> ClientProducts { get; set; }
        virtual public DbSet<Manufacturer> Manufacturers { get; set; }
        virtual public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BreedEntityConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientEntityConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientProductEntityConfiguration).Assembly);
        }
    }
}

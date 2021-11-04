using Microsoft.EntityFrameworkCore;
using RealEstates.Models;

namespace RealEstates.Data
{
    public class RealEstatesDbContext : DbContext
    {
        public RealEstatesDbContext()
        {
        }
        public RealEstatesDbContext(DbContextOptions<RealEstatesDbContext> options)
            :base(options)
        {
        }

        public virtual DbSet<BuildingType> BuildingTypes { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<RealEstateProperty> RealEstateProperties { get; set; }
        public virtual DbSet<RealEstatePropertyTag> RealEstatePropertyTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=RealEstates;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealEstatePropertyTag>(entity =>
            {
                entity.HasKey(x => new { x.RealEstatePropertyId, x.TagId });
            });
        }
    }
}

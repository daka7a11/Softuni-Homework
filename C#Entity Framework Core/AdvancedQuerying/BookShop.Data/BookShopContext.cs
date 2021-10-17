
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class BookShopContext:DbContext
    {
        public BookShopContext()
        {
        }
        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q72FB2M\SQLEXPRESS;Database=BookShop;Integrated Security=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(x => x.FirstName).IsUnicode();

                entity.Property(x => x.LastName).IsUnicode();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(x => x.Title).IsUnicode();

                entity.Property(x => x.Description).IsUnicode();

                entity.HasOne(b => b.Author)
                      .WithMany(a => a.Books)
                      .HasForeignKey(b => b.AuthorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode();
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasKey(x => new { x.BookId, x.CategoryId });

                entity.HasOne(bc => bc.Book)
                      .WithMany(b => b.BookCategories)
                      .HasForeignKey(bc => bc.BookId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(bc => bc.Category)
                      .WithMany(c => c.CategoryBooks)
                      .HasForeignKey(bc => bc.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

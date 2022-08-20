using FluffyDuffyMunchkinCats.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FluffyDuffyMunchkinCats.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public virtual DbSet<Cat> Cats { get; set; }
    }
}

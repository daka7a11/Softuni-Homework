using FluffyDuffyMunchkinCats.Data;
using FluffyDuffyMunchkinCats.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluffyDuffyMunchkinCats.Services
{
    public class CatsService : ICatsService
    {
        private readonly ApplicationDbContext db;

        public CatsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Create(string name, int age, string breed, string imageUrl)
        {
            Cat cat = new Cat()
            {
                Name = name,
                Age = age,
                Breed = breed,
                ImageUrl = imageUrl,
            };

            await db.Cats.AddAsync(cat);
            await db.SaveChangesAsync();
        }

        public ICollection<string> GetAllCatNames()
        {
            return db.Cats
                .Select(x => x.Name)
                .ToList();
        }

        public ICollection<Cat> GetAll()
        {
            return db.Cats
                .ToList();
        }
    }
}

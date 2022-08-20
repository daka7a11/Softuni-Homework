using FluffyDuffyMunchkinCats.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluffyDuffyMunchkinCats.Services
{
    public interface ICatsService
    {
        public ICollection<string> GetAllCatNames();

        public Task Create(string name, int age, string breed, string imageUrl);

        public ICollection<Cat> GetAll();
    }
}

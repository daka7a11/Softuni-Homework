using Git.Models;
using Git.ViewModels;
using SUS.HTTP;
using System.Collections.Generic;

namespace Git.Services.Repositories
{
    public interface IRepositoriesService
    {
        public string Create(string name, string type, string userId);

        public ICollection<RepositoryViewModel> GetAll();

        public string GetNameById(string id);

        public string GetIdByName(string name);
    }
}

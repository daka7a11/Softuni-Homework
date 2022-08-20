using Git.ViewModels;
using System.Collections.Generic;

namespace Git.Services.Commits
{
    public interface ICommitsService
    {
        public void Create(string description, string repositoryId, string userId);

        public ICollection<AllCommitsViewModel> GetAll(string userId);

        public void Delete(string id);
    }
}

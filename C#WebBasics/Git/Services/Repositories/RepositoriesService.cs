using Git.Data;
using Git.Models;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services.Repositories
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Create(string name, string type, string userId)
        {
            Repository rep = new Repository()
            {
                Name = name,
                IsPublic = type == "Public" ? true : false,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,
            };

            db.Repositories.Add(rep);
            db.SaveChanges();

            return rep.Id;
        }

        public ICollection<RepositoryViewModel> GetAll()
        {
            return db.Repositories.Where(x => x.IsPublic == true)
                .Select(x => new RepositoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Owner = x.Owner.Username,
                    CreatedOn = x.CreatedOn,
                    CommitsCount = x.Commits.Count
                })
                .OrderByDescending(x => x.CreatedOn)
                .ToList();
        }

        public string GetNameById(string id)
        {
            return db.Repositories.FirstOrDefault(x => x.Id == id).Name;
        }
        public string GetIdByName(string name)
        {
            return db.Repositories.FirstOrDefault(x => x.Name == name).Id;
        }
    }
}

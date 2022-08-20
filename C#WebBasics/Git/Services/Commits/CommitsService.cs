using Git.Data;
using Git.Models;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services.Commits
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string description, string repositoryId, string userId)
        {
            Commit commit = new Commit()
            {
                Description = description,
                RepositoryId = repositoryId,
                CreatorId = userId,
                CreatedOn = DateTime.UtcNow,
            };

            db.Commits.Add(commit);
            db.SaveChanges();
        }

        public ICollection<AllCommitsViewModel> GetAll(string userId)
        {
            return db.Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new AllCommitsViewModel()
                {
                    Id = x.Id,
                    RepositoryName = x.Repository.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn
                })
                .OrderByDescending(x => x.CreatedOn)
                .ToList();
        }

        public void Delete(string id)
        {
            Commit commit = db.Commits.FirstOrDefault(x => x.Id == id);

            if (commit != null)
            {
                db.Commits.Remove(commit);
                db.SaveChanges();
            }
        }
    }
}

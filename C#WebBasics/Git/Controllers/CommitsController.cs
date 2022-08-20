using Git.Services.Commits;
using Git.Services.Repositories;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        private readonly ICommitsService commitsService;

        public CommitsController(IRepositoriesService repositoriesService, ICommitsService commitsService)
        {
            this.repositoriesService = repositoriesService;
            this.commitsService = commitsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            string userId = this.GetUserId();

            var commits = commitsService.GetAll(userId);

            return this.View(commits);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            string repositoryName = repositoriesService.GetNameById(id);
            string userId = this.GetUserId();

            CreateCommitRepositoryViewModel viewModel = new CreateCommitRepositoryViewModel()
            {
                RepositoryName = repositoryName,
                UserId = userId,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string description, string userId, string repositoryName)
        {
            if (description.Length < 5)
            {
                return this.Error("Description should contains more than 5 characters!");
            }

            string repositoryId = repositoriesService.GetIdByName(repositoryName);

            commitsService.Create(description,repositoryId, userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            commitsService.Delete(id);

            return this.Redirect("/Commits/All");
        }
    }
}

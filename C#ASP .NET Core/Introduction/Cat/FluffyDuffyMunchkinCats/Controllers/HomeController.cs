using FluffyDuffyMunchkinCats.Models;
using FluffyDuffyMunchkinCats.Services;
using FluffyDuffyMunchkinCats.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FluffyDuffyMunchkinCats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatsService catsService;

        public HomeController(ILogger<HomeController> logger, ICatsService catsService)
        {
            _logger = logger;
            this.catsService = catsService;
        }

        public IActionResult Index()
        {
            var catNames = catsService.GetAllCatNames();
            IndexViewModel viewModel = new IndexViewModel()
            {
                ProjectName = nameof(FluffyDuffyMunchkinCats),
                CatNames = catNames,
            };

            return View(viewModel);
        }

        public IActionResult AddCat()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddCat(string name, int age, string breed, string imageUrl)
        {
            catsService.Create(name,age,breed,imageUrl);

            return this.View();
        }

        public IActionResult Cats()
        {
            var cats = catsService.GetAll();

            return this.View(cats);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

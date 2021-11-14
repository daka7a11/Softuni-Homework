using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstates.Services.Inferfaces;
using RealEstates.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstates.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDistrictsService districtsService;

        public HomeController(ILogger<HomeController> logger, IDistrictsService districtsService)
        {
            _logger = logger;
            this.districtsService = districtsService;
        }

        public IActionResult Index()
        {
            var districts = districtsService.GetTopDistrictByAveragePrice(100);
            return View(districts);
        }

        public IActionResult Search()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

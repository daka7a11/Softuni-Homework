using Microsoft.AspNetCore.Mvc;
using RealEstates.Services.Inferfaces;

namespace RealEstates.WebApplication.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertiesService propertiesService;
        public PropertiesController(IPropertiesService propertiesService)
        {
            this.propertiesService = propertiesService;
        }

        public IActionResult Search(int minPrice, int maxPrice)
        {
            var properties = propertiesService.SearchByPrice(minPrice, maxPrice);
            if (minPrice == 0 && maxPrice == 0)
            {
                properties = null;
            }
            return this.View(properties);
        }

        public IActionResult DoSearch(int minPrice, int maxPrice)
        {
            var properties = propertiesService.SearchByPrice(minPrice, maxPrice);
            return this.View(properties);
        }
    }
}

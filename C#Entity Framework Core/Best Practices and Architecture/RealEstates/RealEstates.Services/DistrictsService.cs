using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Inferfaces;
using RealEstates.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RealEstates.Services
{
    public class DistrictsService : IDistrictsService
    {
        private RealEstatesDbContext db;
        public DistrictsService(RealEstatesDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictByAveragePrice(int count = 10)
        {
            return db.Districts
                .Select(MapDistrictToDistrictViewModel())
                .OrderByDescending(x => x.AveragePrice)
                .Take(count)
                .AsEnumerable();
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictByPropertiesCount(int count = 10)
        {
            return db.Districts
                .Select(MapDistrictToDistrictViewModel())
                .OrderByDescending(x => x.PropertiesCount)
                .Take(count)
                .AsEnumerable();
        }

        private Expression<Func<District, DistrictViewModel>> MapDistrictToDistrictViewModel()
        {
            return x => new DistrictViewModel()
            {
                Name = x.Name,
                MinPrice = x.RealEstateProperties.Min(p => p.Price),
                MaxPrice = x.RealEstateProperties.Max(p => p.Price),
                AveragePrice = x.RealEstateProperties.Average(p => p.Price),
                PropertiesCount = x.RealEstateProperties.Count
            };
        }
    }
}

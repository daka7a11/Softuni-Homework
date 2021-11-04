using RealEstates.Models;
using RealEstates.Services.ViewModels;
using System.Collections.Generic;

namespace RealEstates.Services.Inferfaces
{
    public interface IPropertiesService
    {
        void Create(double? size, int? floor, int? totalFloors,
            string district, int? year, string propertyType,
            string buildingType, decimal price);

        void UpdateTags(int propId);

        IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize);
        IEnumerable<PropertyViewModel> SearchByPrice(decimal minPrice, decimal maxPrice);
    }
}

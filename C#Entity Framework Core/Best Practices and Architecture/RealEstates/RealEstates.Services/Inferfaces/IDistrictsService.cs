using RealEstates.Services.ViewModels;
using System.Collections.Generic;

namespace RealEstates.Services.Inferfaces
{
    public interface IDistrictsService
    {
        IEnumerable<DistrictViewModel> GetTopDistrictByAveragePrice(int count = 10);
        IEnumerable<DistrictViewModel> GetTopDistrictByPropertiesCount(int count = 10);
    }
}

using Newtonsoft.Json;
using RealEstates.Data;
using RealEstates.Services;
using System.Collections.Generic;
using System.IO;

namespace RealEstates.Importer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new RealEstatesDbContext();
            string json = File.ReadAllText("imot.bg-raw-data-2020-07-23.json");
            var importedProperties = JsonConvert.DeserializeObject<IEnumerable<ImportInfoDTO>>(json);

            var propService = new PropertiesService(db);

            foreach (var prop in importedProperties)
            {
                try
                {
                    propService.Create
                   (
                       prop.Size,
                       prop.Floor,
                       prop.TotalFloors,
                       prop.District,
                       prop.Year,
                       prop.Type,
                       prop.BuildingType,
                       prop.Price
                   );
                }
                catch
                {
                }
            }
        }
    }
}

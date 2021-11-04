using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;
using System;
using System.Text;

namespace RealEstates.ConsoleApplication
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            RealEstatesDbContext db = new RealEstatesDbContext();

            db.Database.Migrate();

            var propService = new PropertiesService(db);

            //Console.Write("Min year:");
            //var minYear = int.Parse(Console.ReadLine());
            //Console.Write("Max year:");
            //var maxYear = int.Parse(Console.ReadLine());
            //Console.Write("Min size:");
            //var minSize = int.Parse(Console.ReadLine());
            //Console.Write("Max size:");
            //var maxSize = int.Parse(Console.ReadLine());

            //var properties = propService.Search(minYear, maxYear, minSize, maxSize);

            //Console.Write("Min price:");
            //var minPrice = int.Parse(Console.ReadLine());
            //Console.Write("Max price:");
            //var maxPrice = int.Parse(Console.ReadLine());

            //var sortedPropsByPrice = propService.SearchByPrice(minPrice, maxPrice);

            //foreach (var prop in sortedPropsByPrice)
            //{
            //    Console.WriteLine($"{prop.DistrictName} => {prop.Year} - {prop.Size}m2 Type: {prop.PropertyType} Floor: {prop.Floor} Price: {prop.Price}€");
            //}

            var districtsService = new DistrictsService(db);

            var districts = districtsService.GetTopDistrictByPropertiesCount(15);

            foreach (var d in districts)
            {
                Console.WriteLine($"{d.Name}  [{d.MinPrice:F2} - {d.MaxPrice:F2}] -> {d.AveragePrice:F2} ==> {d.PropertiesCount}");
            }
        }
    }
}

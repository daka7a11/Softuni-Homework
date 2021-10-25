using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.Datasets.DTO.Cars;
using CarDealer.Datasets.DTO.Customers;
using CarDealer.Datasets.DTO.Parts;
using CarDealer.Datasets.DTO.Sales;
using CarDealer.Datasets.DTO.Suppliers;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        private const string ResultDirectoryPath = "../../../Datasets/ExportJsonFiles";

        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();
            mapper = InitializeMapper();

            //ResetDatabase(db);

            ////Query 08
            //string inputJsonSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(db, inputJsonSuppliers));

            ////Query 09
            //string inputJsonParts = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(db, inputJsonParts));

            ////Query 10
            //string inputJsonCars = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(db, inputJsonCars));

            //Console.WriteLine(ImportPartCar(db, inputJsonCars));

            ////Query 11
            //string inputJsonCustomers = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(db, inputJsonCustomers));

            ////Query 12
            //string inputJsonSales = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(db, inputJsonSales));

            EnsureDirectoryCreated(ResultDirectoryPath);

            //Query 13
            string orderedCustomersJson = GetOrderedCustomers(db);
            ExportFile(ResultDirectoryPath, "ordered-customers.json", orderedCustomersJson);

            string toyotaCarsJson = GetCarsFromMakeToyota(db);
            ExportFile(ResultDirectoryPath, "toyota-cars.json", toyotaCarsJson);

            //Query 14
            string localSuppliers = GetLocalSuppliers(db);
            ExportFile(ResultDirectoryPath, "local-suppliers.json", localSuppliers);

            //Query 15
            string carsParts = GetCarsWithTheirListOfParts(db);
            ExportFile(ResultDirectoryPath, "cars-and-parts.json", carsParts);

            //Query 16
            string customersTotalSales = GetTotalSalesByCustomer(db);
            ExportFile(ResultDirectoryPath, "customers-total-sales.json", customersTotalSales);

            //Query 17
            string salesDiscounts = GetSalesWithAppliedDiscount(db);
            ExportFile(ResultDirectoryPath, "sales-discounts.json", salesDiscounts);
        }
        #region ImportData
        public static string ImportSuppliers(CarDealerContext db, string inputJson)
        {
            var suppliersDTO = JsonConvert.DeserializeObject<List<ImportSupplierDTO>>(inputJson);
            var suppliers = mapper.Map<List<Supplier>>(suppliersDTO);

            db.Suppliers.AddRange(suppliers);
            db.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext db, string inputJson)
        {
            List<int> suppliersId = db.Suppliers.Select(x => x.Id).ToList();

            var partsDTO = JsonConvert.DeserializeObject<List<ImportPartDTO>>(inputJson)
                .Where(x => suppliersId.Contains(x.SupplierId));
            var parts = mapper.Map<List<Part>>(partsDTO);

            db.Parts.AddRange(parts);
            db.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext db, string inputJson)
        {
            var carsDTO = JsonConvert.DeserializeObject<List<ImportCarDTO>>(inputJson);
            var cars = mapper.Map<List<Car>>(carsDTO);

            db.Cars.AddRange(cars);
            db.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportPartCar(CarDealerContext db, string inputJsonCars)
        {
            var carsDTO = JsonConvert.DeserializeObject<List<ImportCarDTO>>(inputJsonCars);

            var cars = db.Cars.ToList();
            var parts = db.Parts.ToList();
            var partCars = new List<PartCar>();
            foreach (var carDTO in carsDTO)
            {
                var car = cars.First(x => x.Make == carDTO.Make
                                       && x.Model == carDTO.Model
                                       && x.TravelledDistance == carDTO.TravelledDistance);

                foreach (var pId in carDTO.PartsId.Distinct())
                {
                    var part = parts.First(x => x.Id == pId);

                    partCars.Add(new PartCar { Car = car, CarId = car.Id, Part = part, PartId = pId });
                }
            }
            db.PartCars.AddRange(partCars);
            db.SaveChanges();
            return $"{partCars.Count} parts added to the cars.";
        }

        public static string ImportCustomers(CarDealerContext db, string inputJson)
        {
            var customersDTO = JsonConvert.DeserializeObject<List<ImportCustomerDTO>>(inputJson);
            var customers = mapper.Map<List<Customer>>(customersDTO);

            db.Customers.AddRange(customers);
            db.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext db, string inputJson)
        {
            var salesDTO = JsonConvert.DeserializeObject<List<ImportSaleDTO>>(inputJson);
            var sales = mapper.Map<List<Sale>>(salesDTO);

            db.AddRange(sales);
            db.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }
        #endregion

        public static string GetOrderedCustomers(CarDealerContext db)
        {
            var customersDTO = db.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ProjectTo<CustomerNameBDIsYoung>(mapper.ConfigurationProvider)
                .ToList();

            string json = JsonConvert.SerializeObject(customersDTO,Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext db)
        {
            var carsDTO = db.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ProjectTo<CarIdMakeModTravDist>(mapper.ConfigurationProvider)
                .ToList();

            string json = JsonConvert.SerializeObject(carsDTO, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext db)
        {
            var suppliersDTO = db.Suppliers
                .Where(x => x.IsImporter == false)
                .ProjectTo<SupplierIdNamePCount>(mapper.ConfigurationProvider)
                .ToList();

            string json = JsonConvert.SerializeObject(suppliersDTO, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext db)
        {
            var carParts = db.Cars
                .Select(x => new CarParts
                {
                    Car = new CarMakeModTrDist() 
                        { Make = x.Make, 
                            Model = x.Model, 
                            TravelledDistance = x.TravelledDistance
                        },
                    Parts = x.PartCars
                        .Select(p => new PartNamePrice() 
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price.ToString("F2")
                        }).ToList()
                })
                .ToList();

            string json = JsonConvert.SerializeObject(carParts, Formatting.Indented);

            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext db)
        {
            var customersDTO = db.Customers
                .Where(x => x.Sales.Count > 0)
                .Include(x => x.Sales)
                .ThenInclude(x => x.Car)
                .ThenInclude(x => x.PartCars)
                .ThenInclude(x => x.Part)
                .ToList()
                .Select(x => new
                {
                    x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.IsYoungDriver ? x.Sales.Sum(c => c.Car.Price) : (x.Sales.Sum(c => c.Car.Price)) * 0.95M
                })
                .OrderByDescending(x => x.SpentMoney)
                .OrderByDescending(x => x.BoughtCars)
                .ToList();

            string json = JsonConvert.SerializeObject(customersDTO, Formatting.Indented);

            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext db)
        {
            var sales = db.Sales
                .Include(x => x.Car)
                .ThenInclude(x => x.PartCars)
                .ThenInclude(x => x.Part)
                .Select(x => new
                {
                    car = new 
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.Price.ToString("F2"),
                    priceWithDiscount = x.Car.Price - ((x.Car.Price * x.Discount)/100)
                })
                .Take(10)
                .ToList();

            string json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }

        private static IMapper InitializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImportSupplierDTO, Supplier>();

                cfg.CreateMap<ImportPartDTO, Part>();

                cfg.CreateMap<ImportCarDTO, Car>();

                cfg.CreateMap<ImportCustomerDTO, Customer>();

                cfg.CreateMap<ImportSaleDTO, Sale>();

                cfg.CreateMap<Customer, CustomerNameBDIsYoung>()
                .ForMember(x => x.BirthDate, y => y.MapFrom(x => x.BirthDate.ToString("dd/MM/yyyy")));

                cfg.CreateMap<Car, CarIdMakeModTravDist>();

                cfg.CreateMap<Supplier, SupplierIdNamePCount>();

                cfg.CreateMap<Part, PartNamePrice>();
            });
            return mapperConfiguration.CreateMapper();
        }

        public static void ExportFile(string path, string fileName, string text)
        {
            File.WriteAllText(path + "/" + fileName, text);
        }
        private static void EnsureDirectoryCreated(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Datasets.Category.DTO;
using ProductShop.Datasets.DTO.Category;
using ProductShop.Datasets.DTO.CategoryProduct;
using ProductShop.Datasets.DTO.Product;
using ProductShop.Datasets.DTO.User;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private const string ExportDirectoryPath = "../../../Datasets/ExportJsonFiles";
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            mapper = InitializeMapper();
            ProductShopContext db = new ProductShopContext();

            #region ImportData
            //string inputJsonUsers = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(db,inputJsonUsers));

            //string inputJsonProducts = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(db, inputJsonProducts));

            //string inputJsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(db, inputJsonCategories));

            //string inputJsonCategoryProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(db, inputJsonCategoryProducts));
            #endregion

            EnsureDirectoryCreated(ExportDirectoryPath);

            //string productInRangeJson = GetProductsInRange(db);
            //File.WriteAllText(ExportDirectoryPath + "/products-in-range.json", productInRangeJson);

            //string usersSoldProducts = GetSoldProducts(db);
            //File.WriteAllText(ExportDirectoryPath + "/users-sold-products.json", usersSoldProducts);

            //string categoriesByProduct = GetCategoriesByProductsCount(db);
            //File.WriteAllText(ExportDirectoryPath + "/categories-by-products.json", categoriesByProduct);

            string usersAndProducts = GetUsersWithProducts(db);
            File.WriteAllText(ExportDirectoryPath + "/users-and-products.json", usersAndProducts);
        }
        #region ImportData
        public static string ImportUsers(ProductShopContext db, string inputJson)
        {
            List<ImportUserDTO> usersDTO = JsonConvert.DeserializeObject<List<ImportUserDTO>>(inputJson);

            List<User> users = mapper.Map<List<User>>(usersDTO);

            db.Users.AddRange(users);
            db.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext db, string inputJson)
        {
            var productDTO = JsonConvert.DeserializeObject<List<ImportProductDTO>>(inputJson);

            var products = mapper.Map<List<Product>>(productDTO);

            db.AddRange(products);
            db.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext db, string inputJson)
        {
            var categoriesDTO = JsonConvert.DeserializeObject<List<ImportCategoryDTO>>(inputJson)
                .Where(x => x.Name != null).ToList();

            var categories = mapper.Map<List<Category>>(categoriesDTO);

            db.Categories.AddRange(categories);
            db.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext db, string inputJson)
        {
            var categoryProductsDTO = JsonConvert.DeserializeObject<List<ImportCategoryProductDTO>>(inputJson);

            var categoryProducts = mapper.Map<List<CategoryProduct>>(categoryProductsDTO);

            db.CategoryProducts.AddRange(categoryProducts);
            db.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        #endregion

        public static string GetProductsInRange(ProductShopContext db)
        {
            var products = db.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .ProjectTo<ProductsInRangeDTO>(mapper.ConfigurationProvider)
                .OrderBy(p => p.Price)
                .ToList();

            string json = JsonConvert.SerializeObject(products, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            return json;
        }

        public static string GetSoldProducts(ProductShopContext db)
        {
            var users = db.Users
                          .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                          .OrderBy(u => u.LastName)
                          .ThenBy(u => u.FirstName)
                          .ProjectTo<UserSoldProductDTO>(mapper.ConfigurationProvider)
                          .ToList();

            string json = JsonConvert.SerializeObject(users, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext db)
        {
            var categories = db.Categories
                .ProjectTo<CategoryByProductDTO>(mapper.ConfigurationProvider)
                .OrderByDescending(x => x.ProductsCount)
                .ToList();

            string json = JsonConvert.SerializeObject(categories, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext db)
        {
            var users = db.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new UserProductsDTO
                {
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = u.ProductsSold.Where(x => x.Buyer != null)
                    .Select(cp => new SoldProductsDTO
                    {
                        Count = cp.CategoryProducts.Count,
                        Products = cp.CategoryProducts.Select(p => new ProductNamePriceDTO
                        {
                            Name = p.Product.Name,
                            Price = p.Product.Price
                        }).ToList()
                    }).ToList()
                }).ToList()
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToList();

            var usersProducts = new UsersCountProducts()
            {
                Users = users
            };

            string json = JsonConvert.SerializeObject(usersProducts, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });
            return json;
        }

        private static IMapper InitializeMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImportUserDTO, User>().ReverseMap();

                cfg.CreateMap<ImportProductDTO, Product>().ReverseMap();

                cfg.CreateMap<ImportCategoryDTO, Category>().ReverseMap();

                cfg.CreateMap<ImportCategoryProductDTO, CategoryProduct>().ReverseMap();

                cfg.CreateMap<Product, ProductsInRangeDTO>()
                .ForMember(x => x.Seller, y => y.MapFrom(x => x.Seller.FirstName + " " + x.Seller.LastName));

                cfg.CreateMap<User, UserSoldProductDTO>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(x => x.ProductsSold));

                cfg.CreateMap<Product, SoldProductDTO>()
                .ForMember(x => x.BuyerFirstName, y => y.MapFrom(x => x.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName, y => y.MapFrom(x => x.Buyer.LastName));

                cfg.CreateMap<Category, CategoryByProductDTO>()
                .ForMember(x => x.Category, y=> y.MapFrom(x => x.Name))
                .ForMember(x => x.ProductsCount, y=> y.MapFrom(x => x.CategoryProducts.Count()))
                .ForMember(x => x.AveragePrice, y=> y.MapFrom(x => x.CategoryProducts.Average(p => p.Product.Price).ToString("F2")))
                .ForMember(x => x.TotalRevenue, y=> y.MapFrom(x => x.CategoryProducts.Sum(p =>p.Product.Price).ToString("F2")));

                cfg.CreateMap<User, SoldProductsDTO>()
                .ForMember(x => x.Count, y => y.MapFrom(x => x.ProductsSold.Count))
                .ForMember(x => x.Products, y => y.MapFrom(x => x.ProductsSold));

                cfg.CreateMap<User, UserProductsDTO>();
            });
            return mapperConfiguration.CreateMapper();
        }
        private static void ResetDataBase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }
        private static void EnsureDirectoryCreated(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
using System.Linq;
using AutoMapper;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                
            });
        }
    }
}

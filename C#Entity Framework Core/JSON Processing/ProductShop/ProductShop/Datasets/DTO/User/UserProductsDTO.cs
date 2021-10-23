using ProductShop.Datasets.DTO.Product;
using System.Collections.Generic;

namespace ProductShop.Datasets.DTO.User
{
    public class UserProductsDTO
    {
        public string LastName { get; set; }
        public int? Age { get; set; }
        public List<SoldProductsDTO> SoldProducts { get; set; }
    }
}

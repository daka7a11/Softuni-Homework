using ProductShop.Datasets.DTO.Product;
using System.Collections.Generic;

namespace ProductShop.Datasets.DTO.User
{
    public class UserSoldProductDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SoldProductDTO> SoldProducts { get; set; }
    }
}

using System.Collections.Generic;

namespace ProductShop.Datasets.DTO.User
{
    public class UsersCountProducts
    {
        public int UsersCount => Users.Count;
        public List<UserProductsDTO> Users { get; set; }
    }
}

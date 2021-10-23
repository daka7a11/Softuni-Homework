using System.Collections.Generic;

namespace ProductShop.Datasets.DTO.Product
{
    public class SoldProductsDTO
    {
        public int Count { get; set; }
        public List<ProductNamePriceDTO> Products { get; set; }
    }
}

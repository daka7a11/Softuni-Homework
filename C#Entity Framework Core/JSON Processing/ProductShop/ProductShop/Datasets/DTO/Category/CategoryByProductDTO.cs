namespace ProductShop.Datasets.DTO.Category
{
    public class CategoryByProductDTO
    {
        public string Category { get; set; }
        public int ProductsCount { get; set; }
        public string AveragePrice { get; set; }
        public string TotalRevenue { get; set; }
    }
}

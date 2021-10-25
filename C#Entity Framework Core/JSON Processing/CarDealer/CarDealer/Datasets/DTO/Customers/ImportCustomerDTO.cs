using System;

namespace CarDealer.Datasets.DTO.Customers
{
    public class ImportCustomerDTO
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsYoungDriver { get; set; }
    }
}

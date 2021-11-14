using PetStore.Common;
using PetStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        [Range(GlobalConstants.ProductMinPrice, double.MaxValue)]
        public decimal Price { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }
    }
}

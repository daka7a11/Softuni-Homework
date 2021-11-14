using PetStore.Common;
using PetStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetStore.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Town { get; set; }

        [Required]
        [MinLength(GlobalConstants.NameMinLength)]
        public string Address { get; set; }
        public string Notes { get; set; }

        [ForeignKey(nameof(Models.ClientProduct))]
        public ICollection<ClientProduct> ClientProducts { get; set; }
        public decimal TotalPrice => ClientProducts.Sum(x => x.Product.Price);
    }
}

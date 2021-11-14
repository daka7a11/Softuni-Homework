using PetStore.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class ClientProduct
    {
        [ForeignKey(nameof(Models.Client))]
        public string ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey(nameof(Models.Product))]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(Models.Order))]
        public string OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        [Range(GlobalConstants.OrderMinQuantity, int.MaxValue)]
        public int Quantity { get; set; }
    }
}

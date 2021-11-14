using PetStore.Common;
using PetStore.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class Toy : ISellable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Models.Manufacturer))]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        [ForeignKey(nameof(Models.Client))]
        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}

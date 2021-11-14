using PetStore.Common;
using PetStore.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class Food : ISellable
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(GlobalConstants.FoodMinKg, double.MaxValue)]
        public double Kg { get; set; }

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

using PetStore.Common;
using PetStore.Models.Enums;
using PetStore.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class Pet : ISellable
    {
        public Pet()
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
        public Gender Gender { get; set; }

        [ForeignKey(nameof(Models.Breed))]
        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        [ForeignKey(nameof(Models.Client))]
        public string ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        [Range(GlobalConstants.PetMinAge, GlobalConstants.PetMaxAge)]
        public int Age { get; set; }

        [Required]
        [Range(GlobalConstants.PetMinPrice, double.MaxValue)]
        public decimal Price { get; set; }
    }
}

using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class Client
    {
        public Client()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientNameMinLength)]
        [MaxLength(GlobalConstants.ClientNameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientPasswordMinLength)]
        public string Password { get; set; }

        [MinLength(GlobalConstants.ClientNameMinLength)]
        [MaxLength(GlobalConstants.ClientNameMaxLength)]
        public string FirstName { get; set; }

        [MinLength(GlobalConstants.ClientNameMinLength)]
        [MaxLength(GlobalConstants.ClientNameMaxLength)]
        public string LastName { get; set; }


        public string Email { get; set; }

        [Range(GlobalConstants.ClientMinAge,GlobalConstants.ClientMaxAge)]
        public int? Age { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }

        [ForeignKey(nameof(Models.Pet))]
        public virtual ICollection<Pet> BoughtPets { get; set; }

        [ForeignKey(nameof(Models.Food))]
        public virtual ICollection<Food> BoughtFoods { get; set; }

        [ForeignKey(nameof(Models.Toy))]
        public virtual ICollection<Toy> BoughtToys { get; set; }
    }
}

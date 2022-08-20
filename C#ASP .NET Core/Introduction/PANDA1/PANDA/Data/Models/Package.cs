using PANDA.Data.Models.Enumerable;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PANDA.Data.Models
{
    public class Package
    {
        public Package()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User Recipient { get; set; }
    }
}

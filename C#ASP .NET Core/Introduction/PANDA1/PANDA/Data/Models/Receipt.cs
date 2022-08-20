using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PANDA.Data.Models
{
    public class Receipt
    {
        public Receipt()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        [ForeignKey(nameof(Models.User))]
        public string UserId { get; set; }
        public User Recipient { get; set; }

        [ForeignKey(nameof(Models.Package))]
        public string PackageId { get; set; }
        public Package Package { get; set; }
    }
}

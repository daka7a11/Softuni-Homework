using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git.Models
{
    public class Commit
    {
        public Commit()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Models.User))]
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        [ForeignKey(nameof(Models.Repository))]
        public string RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}

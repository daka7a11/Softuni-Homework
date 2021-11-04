using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class PropertyType
    {
        public PropertyType()
        {
            RealEstateProperties = new HashSet<RealEstateProperty>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }

        public virtual ICollection<RealEstateProperty> RealEstateProperties { get; set; }
    }
}

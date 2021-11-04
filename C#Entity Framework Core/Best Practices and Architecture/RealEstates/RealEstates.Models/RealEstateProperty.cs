using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class RealEstateProperty
    {
        public RealEstateProperty()
        {
            Tags = new HashSet<RealEstatePropertyTag>();
        }
        [Key]
        public int Id { get; set; }

        public double? Size { get; set; }
        public int? Floor { get; set; }
        public int? TotalNumberOfFloors { get; set; }

        [Required]
        public int DistrictId { get; set; }
        public District District { get; set; }

        public int? BuildingYear { get; set; }

        public int? PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }

        public int? BuildingTypeId { get; set; }
        public BuildingType BuildingType { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<RealEstatePropertyTag> Tags { get; set; }
    }
}

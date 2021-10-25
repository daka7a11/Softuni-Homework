using CarDealer.Datasets.DTO.Parts;
using System.Collections.Generic;

namespace CarDealer.Datasets.DTO.Cars
{
    public class CarParts
    {
            public CarMakeModTrDist Car { get; set; }
            public List<PartNamePrice> Parts { get; set; }
    }
}

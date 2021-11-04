using AutoMapper;
using AutoMapper.QueryableExtensions;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Inferfaces;
using RealEstates.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstates.Services
{
    public class PropertiesService : IPropertiesService
    {
        private readonly RealEstatesDbContext db;
        private IMapper mapper;
        public PropertiesService(RealEstatesDbContext db)
        {
            this.db = db;
            mapper = InitMapper();
        }

        public void Create(double? size, int? floor, int? totalFloors, string district,
            int? year, string propertyType, string buildingType, decimal price)
        {
            if (district == null)
            {
                throw new InvalidOperationException(nameof(district));
            }
            if (price <= 0)
            {
                throw new InvalidOperationException(nameof(price));
            }

            var prop = new RealEstateProperty
            {
                Size = size <= 0 ? null : size,
                Floor = floor <= 0 ? null : floor,
                TotalNumberOfFloors = totalFloors <= 0 ? null : totalFloors,
                BuildingYear = year <= 1800 ? null : year,
                Price = price
            };
            //District
            var districtDb = this.db.Districts.FirstOrDefault(x => x.Name.Trim() == district.Trim());

            if (districtDb == null)
            {
                districtDb = new District() { Name = district };
            }
            prop.District = districtDb;

            //PropertyType
            var propTypeDb = db.PropertyTypes.FirstOrDefault(x => x.Type.Trim().ToLower() == propertyType.Trim().ToLower());

            if (propTypeDb == null)
            {
                propTypeDb = new PropertyType() { Type = propertyType };
            }
            prop.PropertyType = propTypeDb;

            //BuildingType
            var buildingTypeDb = db.BuildingTypes.FirstOrDefault(x => x.Type.Trim().ToLower() == buildingType.Trim().ToLower());

            if (buildingTypeDb == null)
            {
                buildingTypeDb = new BuildingType() { Type = buildingType };
            }
            prop.BuildingType = buildingTypeDb;

            db.RealEstateProperties.Add(prop);
            db.SaveChanges();

            UpdateTags(prop.Id);
        }
        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize)
        {
            var properties = db.RealEstateProperties
                .Where(x => x.BuildingYear >= minYear &&
                            x.BuildingYear <= maxYear &&
                            x.Size >= minSize &&
                            x.Size <= maxSize)
                .ProjectTo<PropertyViewModel>(mapper.ConfigurationProvider)
                .AsEnumerable();

            return properties;
        }

        public IEnumerable<PropertyViewModel> SearchByPrice(decimal minPrice, decimal maxPrice)
        {
            var properties = db.RealEstateProperties
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .ProjectTo<PropertyViewModel>(mapper.ConfigurationProvider)
                .OrderBy(x => x.Price)
                .AsEnumerable();

            return properties;
        }

        public void UpdateTags(int propId)
        {
            var prop = db.RealEstateProperties.FirstOrDefault(x => x.Id == propId);

            if (prop.BuildingYear < 2000)
            {
                prop.Tags.Add(new RealEstatePropertyTag()
                {
                    Tag = GetOrCreateTag("OldBuilding")
                });
            }
            if (prop.Floor == prop.TotalNumberOfFloors)
            {
                prop.Tags.Add(new RealEstatePropertyTag()
                {
                    Tag = GetOrCreateTag("LastFloor")
                });
            }
            if (prop.Size != null)
            {
                if ((prop.Price / (decimal)prop.Size) <= 900)
                {
                    prop.Tags.Add(new RealEstatePropertyTag()
                    {
                        Tag = GetOrCreateTag("CheapProperty")
                    });
                }
                else if ((prop.Price / (decimal)prop.Size) >= 1800)
                {
                    prop.Tags.Add(new RealEstatePropertyTag()
                    {
                        Tag = GetOrCreateTag("ExpensiveProperty")
                    });
                }
            }

            db.SaveChanges();
        }

        private IMapper InitMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RealEstateProperty, PropertyViewModel>()
                .ForMember(x => x.Floor, y => y.MapFrom(x => (x.Floor == null ? 0 : x.Floor) 
                                                           + "/" 
                                                           + (x.TotalNumberOfFloors == null ? 0 : x.TotalNumberOfFloors)))
                .ForMember(x => x.DistrictName, y => y.MapFrom(x => x.District.Name))
                .ForMember(x => x.Year, y => y.MapFrom(x => x.BuildingYear))
                .ForMember(x => x.PropertyType, y => y.MapFrom(x => x.PropertyType.Type))
                .ForMember(x => x.BuildingType, y => y.MapFrom(x => x.BuildingType.Type));
            });
            return mapperConfiguration.CreateMapper();
        }
        private Tag GetOrCreateTag(string tagName)
        {
            var tag = db.Tags.FirstOrDefault(x => x.Name.Trim().ToLower() == tagName.Trim().ToLower());
            if (tag == null)
            {
                tag = new Tag() { Name = tagName };
            }
            return tag;
        }
    }
}

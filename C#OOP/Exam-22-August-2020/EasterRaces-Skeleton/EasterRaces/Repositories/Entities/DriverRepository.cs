﻿
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> drivers;

        public DriverRepository()
        {
            drivers = new List<IDriver>();
        }

        public void Add(IDriver model)
        {
            drivers.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return drivers.ToArray();
        }

        public IDriver GetByName(string name)
        {
            return drivers.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDriver model)
        {
            return drivers.Remove(model);
        }
    }
}

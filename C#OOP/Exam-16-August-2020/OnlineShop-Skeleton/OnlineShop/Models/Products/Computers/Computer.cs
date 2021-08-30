
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components;

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;

        public void AddComponent(IComponent component)
        {
            if (components.Any(c => c.GetType() == component.GetType()))
            {
                throw new ArgumentException(String.Join(ExceptionMessages.ExistingComponent,
                    component.GetType().Name,
                    this.GetType().Name,
                    Id));
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(p => p.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException(String.Join(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name,
                    this.GetType().Name,
                    Id));
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent,
                    componentType,
                    this.GetType().Name,
                    Id));
            }
            var componentToRemove = components.First(c => c.GetType().Name == componentType);
            components.Remove(componentToRemove);
            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!peripherals.Any(p => p.GetType().Name == peripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent,
                    peripheralType,
                    this.GetType().Name,
                    Id));
            }
            var peripheralToRemove = peripherals.First(p => p.GetType().Name == peripheralType);
            peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }

        public override double OverallPerformance
        {
            get
            {
                if (Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    double result = base.OverallPerformance + Components.Average(c => c.OverallPerformance);
                    return result;
                }
            }
        }

        public override decimal Price
        {
            get
            {
                decimal componentsPrice = Components.Sum(c => c.Price);
                decimal peripheralPrice = Peripherals.Sum(p => p.Price);
                return base.Price + componentsPrice + peripheralPrice;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine($" Components ({Components.Count}):");
            foreach (var component in Components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }
            string averagePeripheralsOverallPerformance = Peripherals.Count == 0 ? "0.00" :
                Peripherals.Average(p => p.OverallPerformance).ToString("F2");
            sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({averagePeripheralsOverallPerformance}):");
            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;


namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherls;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherls = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)this.components;
        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)this.peripherls;

        // One of my biggest mistakes. I was returned this.OverallPerformance instead of base.OverallPerfomance and that causes StackOverflow
        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance + this.components.Average(c => c.OverallPerformance);
            }
        }


        // One of my biggest mistakes. I was returned this.Price instead of base.Price and that causes StackOverflow
        public override decimal Price
        {
            get
            {

                return base.Price + this.components.Sum(c => c.Price) +
                       this.peripherls.Sum(p => p.Price);

            }
        }


        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(
                    $"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = this.components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (this.components.Count == 0 || component == null)
            {
                throw new ArgumentException(
                    $"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            this.components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherls.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(
                    $"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherls.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = this.peripherls.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (this.peripherls.Count == 0 || peripheral == null)
            {
                throw new ArgumentException(
                    $"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            this.peripherls.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($" Components ({this.Components.Count}):");

            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine(
                $" Peripherals ({this.Peripherals.Count}); Average Overall Performance " +
                $"({this.peripherls.Average(p => p.OverallPerformance)}):");

            foreach (var peripheral in this.Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;


        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);

            if (computer != null)
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            if (computerType == Common.Enums.ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == Common.Enums.ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            this.computers.Add(computer);

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }


            IPeripheral peripheral = this.peripherals.FirstOrDefault(c => c.Id == id);

            if (peripheral != null)
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            if (peripheralType == Common.Enums.PeripheralType.Headset.ToString())
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance,connectionType);
            }
            else if (peripheralType == Common.Enums.PeripheralType.Keyboard.ToString())
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == Common.Enums.PeripheralType.Monitor.ToString())
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == Common.Enums.PeripheralType.Mouse.ToString())
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);

            this.peripherals.Remove(peripheral);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }


            IComponent component = this.components.FirstOrDefault(c => c.Id == id);

            if (component != null)
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            if (componentType == Common.Enums.ComponentType.CentralProcessingUnit.ToString())
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == Common.Enums.ComponentType.Motherboard.ToString())
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == Common.Enums.ComponentType.PowerSupply.ToString())
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == Common.Enums.ComponentType.RandomAccessMemory.ToString())
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == Common.Enums.ComponentType.SolidStateDrive.ToString())
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == Common.Enums.ComponentType.VideoCard.ToString())
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            this.components.Add(component);
            computer.AddComponent(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComponent component = computer.RemoveComponent(componentType);

            this.components.Remove(component);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string BuyComputer(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            var affordableComputers = this.computers.Where(c => c.Price <= budget)
                .OrderByDescending(c => c.OverallPerformance).ToList();

            if (affordableComputers.Count == 0 || this.computers.Count == 0)
            {
                throw new ArgumentException(String.Format(Common.Constants.ExceptionMessages.CanNotBuyComputer, budget));
            }

            var theBestComputer = affordableComputers[0];

            this.computers.Remove(theBestComputer);

            return theBestComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computer.ToString();
                
        }
    }
}

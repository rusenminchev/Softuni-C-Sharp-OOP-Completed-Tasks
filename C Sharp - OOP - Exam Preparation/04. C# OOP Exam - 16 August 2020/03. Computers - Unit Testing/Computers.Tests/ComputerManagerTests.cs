using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;

        private Computer firstComputer;
        private Computer secondComputer;
        private Computer thirdComputer;

        [SetUp]
        public void Setup()
        {
            this.computerManager = new ComputerManager();

            this.firstComputer = new Computer("Asus", "X1", 200.00m);
            this.secondComputer = new Computer("Asus", "X5", 300.00m);
            this.thirdComputer = new Computer("Apple", "MacBook", 300.00m);
        }

        [Test]
        public void ConstructorIsWorkingCorectly()
        {
            Assert.IsNotNull(this.computerManager);
        }

        [Test]
        public void AddMethodShouldAddComputerAndIncreaseTheCount()
        {
            this.computerManager.AddComputer(this.firstComputer);

            Assert.AreEqual(1, this.computerManager.Count);
        }

        [Test]
        public void AddMethodShouldAddComputerToTheCollection()
        {
            this.computerManager.AddComputer(this.firstComputer);

            var computers = computerManager.Computers.ToList();

            Assert.AreEqual("Asus", computers[0].Manufacturer);
            Assert.AreEqual("X1", computers[0].Model);
        }


        [Test]
        public void AddMethodShouldThrowIfComputerIsNull()
        {
            Computer computer = null;


            Assert.That(() => this.computerManager.AddComputer(computer),
                Throws.ArgumentNullException);
        }

        [Test]
        public void AddMethodShouldThrowIfComputerAlreadyExists()
        {
            this.computerManager.AddComputer(this.firstComputer);

           Assert.That(() => this.computerManager.AddComputer(this.firstComputer),
               Throws.ArgumentException);
        }

        [Test]
        public void GetComputerSouldCheckIfTheComputerExistsAndReturnIt()
        {
            this.computerManager.AddComputer(this.firstComputer);
            this.computerManager.AddComputer(this.secondComputer);
            this.computerManager.AddComputer(this.thirdComputer);

            string manufacturer = "Asus";
            string model = "X1";

            Computer expectedComputer = this.computerManager.Computers
                .FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            var actualComputer = this.computerManager.GetComputer(manufacturer, model);

            Assert.AreEqual(expectedComputer.Manufacturer, actualComputer.Manufacturer);
            Assert.AreEqual(expectedComputer.Model, actualComputer.Model);
        }

        [Test]
        public void GetComputerSouldThrowIfTheComputerDoesNotExist()
        {
            this.computerManager.AddComputer(this.firstComputer);
            this.computerManager.AddComputer(this.secondComputer);
            this.computerManager.AddComputer(this.thirdComputer);

            string manufacturer = "Asis";
            string model = "X2";

            Computer expectedComputer = this.computerManager.Computers
                .FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            Assert.That(() => this.computerManager.GetComputer(manufacturer, model),
                Throws.ArgumentException);
            
        }

        [Test]
        public void RemoveComputerIsWorkingCorrectly()
        {
            this.computerManager.AddComputer(this.firstComputer);
            this.computerManager.AddComputer(this.secondComputer);
            this.computerManager.AddComputer(this.thirdComputer);

            string manufacturer = "Asus";
            string model = "X1";

            Computer expectedComputer = this.computerManager.Computers
                .FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            var actualComputer = this.computerManager.RemoveComputer(manufacturer, model);

            Assert.AreEqual(expectedComputer.Manufacturer, actualComputer.Manufacturer);
        }

        [Test]
        public void RemoveMethodShouldDecreaseTheCount()
        {
            this.computerManager.AddComputer(this.firstComputer);
            this.computerManager.AddComputer(this.secondComputer);
            this.computerManager.AddComputer(this.thirdComputer);

            string manufacturer = "Asus";
            string model = "X1";

            var actualComputer = this.computerManager.RemoveComputer(manufacturer, model);

            Assert.AreEqual(2, this.computerManager.Count);
        }

        [TestCase(null)]
        public void RemoveComputer(string value)
        {
            Computer computer = new Computer("HP", "Device200", 700);
            this.computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer(value, "J230"));
            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer("HP", value));
        }

        [Test]
        public void GetComputersByManufacturerIsWorkingCorectly()
        {
            this.computerManager.AddComputer(this.firstComputer);
            this.computerManager.AddComputer(this.secondComputer);
            this.computerManager.AddComputer(this.thirdComputer);

            string manufacturer = "Asus";
            string model = "X1";


            ICollection<Computer> computers = this.computerManager.Computers
                .Where(c => c.Manufacturer == manufacturer)
                .ToList();

            var result = this.computerManager.GetComputersByManufacturer(manufacturer);

            CollectionAssert.AreEqual(computers,result);
        }


    }
}
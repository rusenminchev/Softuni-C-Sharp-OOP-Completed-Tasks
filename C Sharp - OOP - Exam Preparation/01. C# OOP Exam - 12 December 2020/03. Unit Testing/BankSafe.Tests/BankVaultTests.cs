using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item firstItem;
        private Item secondItem;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();

            this.firstItem = new Item("Ivan", "1");
            this.secondItem = new Item("Gosho", "2");
        }

        [Test]
        public void ConstructorIsWorkingCorrectlyWhenInitialiseCollectionWith12Elements()
        {
            int expectedCount = 12;

            BankVault bankVoult = new BankVault();

            int actualCount = bankVault.VaultCells.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodShouldAddNewItemCorrectly()
        {
           
            string expectedMessage = $"Item:{this.firstItem.ItemId} saved successfully!";

            string actualMessage = this.bankVault.AddItem("A1", this.firstItem);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfTheGivenCellDoesNotExist()
        {
           Assert.That(() => this.bankVault.AddItem("Missing Cell", this.firstItem),
               Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfTheCellIsNotNull()
        {
            this.bankVault.AddItem("A1", this.secondItem);

            Assert.That(() => this.bankVault.AddItem("A1", this.firstItem),
                Throws.ArgumentException.With.Message.EqualTo("Cell is already taken!"));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfTheIsAlreadyInACell()
        {
            this.bankVault.AddItem("A1", this.firstItem);

            Assert.That(() => this.bankVault.AddItem("A2", this.firstItem),
                Throws.InvalidOperationException.With.Message.EqualTo("Item is already in cell!"));
        }

        [Test]
        public void RemoveMethodShouldRemoveExistingItemCorrectly()
        {
            string expectedMessage = $"Remove item:{this.firstItem.ItemId} successfully!";

            this.bankVault.AddItem("A1", this.firstItem);

            string actualMessage = this.bankVault.RemoveItem("A1", this.firstItem);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void RemoveMethodSHouldThrowExceptionIfTheGivenCellDoesNotExist()
        {
            Assert.That(() => this.bankVault.RemoveItem("Missing Cell", this.firstItem),
                  Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));

        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfTheGivenItemDoesNotExistInTheGivenCell()
        {
            this.bankVault.AddItem("A1", this.secondItem);

            Assert.That(() => this.bankVault.RemoveItem("A1", this.firstItem),
                Throws.ArgumentException.With.Message.EqualTo($"Item in that cell doesn't exists!"));
        }
    }
}
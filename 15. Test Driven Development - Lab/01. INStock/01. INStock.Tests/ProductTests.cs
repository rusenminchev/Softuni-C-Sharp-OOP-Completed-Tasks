using INStock.Contracts;
using INStock.Models;
using NUnit.Framework;
using System;

namespace INStock.Tests
{

    [TestFixture]
    public class ProductTests
    {

        private IProduct firstProduct;
        private IProduct secondProduct;

        [SetUp]
        public void SetUp()
        {
            this.firstProduct = new Product("Johny Walker", 20.00m, 100);
            this.secondProduct = new Product("Johny Walker", 20.00m, 100);
        }

        [Test]
        public void TheConstructorShouldSetLabelPriceAndQuantityCorrectly()
        {
            string expectedLabel = "Johny Walker";
            decimal expectedPrice = 20.00m;
            int expectedQuantity = 100;

            IProduct product = new Product(expectedLabel, expectedPrice, expectedQuantity);

            string actualLabel = product.Label;
            decimal actualPrice = product.Price;
            int actualQuantity = product.Quantity;

            Assert.AreEqual(expectedLabel, actualLabel);
            Assert.AreEqual(expectedPrice, actualPrice);
            Assert.AreEqual(expectedQuantity, actualQuantity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void LabelShouldThrowExceptionIfTheInputIsNullOrEmpty(string expectedLabel)
        {
            decimal expectedPrice = 20.00m;
            int expectedQuantity = 100;

            Assert.That(() => { IProduct product = new Product(expectedLabel, expectedPrice, expectedQuantity); },
                Throws
                .ArgumentException.With.Message.EqualTo("Label cannot be null or empty!"));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void PriceShouldThrowExceptionIfTheInputIsNegative(decimal expectedPrice)
        {
            string expectedLabel = "Johny Walker";
            int expectedQuantity = 100;

            Assert.That(() => { IProduct product = new Product(expectedLabel, expectedPrice, expectedQuantity); },
                Throws
                .ArgumentException.With.Message.EqualTo("Price cannot be negative!"));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void QuantityShouldThrowExceptionIfTheInputIsNegative(int expectedQuantity)
        {
            string expectedLabel = "Johny Walker";
            decimal expectedPrice = 20.00m;

            Assert.That(() => { IProduct product = new Product(expectedLabel, expectedPrice, expectedQuantity); },
                Throws
                .ArgumentException.With.Message.EqualTo("Quantity cannot be negative!"));
        }

        [Test]
        public void CompareToShouldReturnZeroIfProductsAreEqual()
        {

            var result = this.firstProduct.CompareTo(this.secondProduct);

            Assert.AreEqual(0, result);
        }
    }
}
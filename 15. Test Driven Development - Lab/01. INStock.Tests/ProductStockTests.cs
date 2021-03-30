namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStockTests
    {
        private IProductStock productStock;

        private IProduct firstProduct;
        private IProduct secondProduct;
        private IProduct thirdProduct;
        private IProduct forthProduct;
        private IProduct fifthProduct;
        private IProduct sixthProduct;


        [SetUp]
        public void SetUp()
        {
            this.productStock = new ProductStock();

            this.firstProduct = new Product("Skittles", 5.00m, 10);
            this.secondProduct = new Product("Zagorka", 10.00m, 20);
            this.thirdProduct = new Product("Astika", 10.00m, 30);
            this.forthProduct = new Product("Mastika", 15.00m, 30);
            this.fifthProduct = new Product("Homemade Rakia", 30.00m, 5);
            this.sixthProduct = new Product("Slanina", 30.00m, 10);
        }

        [Test]
        public void ConstructorShouldInstanceCollectionOfIProduct()
        {
            IProductStock productStock = new ProductStock();

            int expectedCount = 0;

            int actualCount = productStock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldAddNewProductCorrectlyAndEncreaseTheCount()
        {
            this.productStock.Add(firstProduct);

            Assert.IsTrue(this.productStock.Contains(firstProduct));
        }

        [Test]
        public void CountShouldIncreaseWhenAddNewProduct()
        {
            this.productStock.Add(firstProduct);

            Assert.AreEqual(1, productStock.Count);
        }

        [Test]
        public void AddShouldThrowExceptionIfTryToAddAnExistingProduct()
        {
            this.productStock.Add(firstProduct);

            Assert.That(() => this.productStock.Add(firstProduct),
                Throws.InvalidOperationException.With.Message.EqualTo("This product is already added"));
        }

        [Test]
        public void RemoveShouldFindAndRemoveProductAndReturnTrueIfSucceed()
        {
            this.productStock.Add(firstProduct);
            this.productStock.Add(secondProduct);

            IProduct productToRemore = new Product("Skittles", 5.00m, 10);


            Assert.IsTrue(this.productStock.Remove(productToRemore));

        }

         [Test]
        public void RemoveShouldReturnFalseIfTheGivenProductNotExist()
        {
            this.productStock.Add(firstProduct);
            this.productStock.Add(secondProduct);

            IProduct productToRemore = new Product("IPhone X", 1500.00m, 10);

            Assert.IsFalse(this.productStock.Remove(productToRemore));

        }

        

        [Test]
        public void FindShouldFindAndReturnProductByGivenIndex()
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            IProduct foundProduct = this.productStock.Find(1);

            Assert.AreEqual(this.secondProduct.Label, foundProduct.Label);
            Assert.AreEqual(this.secondProduct.Price, foundProduct.Price);
            Assert.AreEqual(this.secondProduct.Quantity, foundProduct.Quantity);
        }

        [TestCase (-1)]
        [TestCase (3)]
        public void FindShouldThrowExceptionIfTheGivenIndexIsOutOfRange(int index)
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            Assert.That(() => this.productStock.Find(index),
                Throws.Exception.InstanceOf<System.IndexOutOfRangeException>()
                .With.Message.EqualTo("Index is out of range"));

        }

        [Test]
        public void FindAllByPriceShouldReturnCollectionWithAllTheProductsWithTheGivenPrice()
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);
            this.productStock.Add(this.thirdProduct);
            this.productStock.Add(this.forthProduct);

            List<IProduct> productsSortedByPrice = this.productStock.FindAllByPrice(10).ToList();

            Assert.AreEqual(this.secondProduct.Label, productsSortedByPrice[0].Label);
            Assert.AreEqual(this.secondProduct.Price, productsSortedByPrice[0].Price);
            Assert.AreEqual(this.secondProduct.Quantity, productsSortedByPrice[0].Quantity);

            Assert.AreEqual(this.thirdProduct.Label, productsSortedByPrice[1].Label);
            Assert.AreEqual(this.thirdProduct.Price, productsSortedByPrice[1].Price);
            Assert.AreEqual(this.thirdProduct.Quantity, productsSortedByPrice[1].Quantity);
        }

        [Test]
        public void FindAllByPriceShouldReturnCollectionWithTheCorrectCount()
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);
            this.productStock.Add(this.thirdProduct);
            this.productStock.Add(this.forthProduct);

            List<IProduct> productsSortedByPrice = this.productStock.FindAllByPrice(10).ToList();

            Assert.AreEqual(2, productsSortedByPrice.Count);
        }

        [Test]
        public void FindAllByPriceShouldReturnEmptyIfThereNoProductsWithTheGivenPrice()
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.thirdProduct);
            this.productStock.Add(this.forthProduct);

            List<IProduct> productsSortedByPrice = this.productStock.FindAllByPrice(100).ToList();

            Assert.AreEqual(0, productsSortedByPrice.Count);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void FindAllByPriceShouldThrowExceptionWhenTheGivenPriceIsLessThanZero(double price)
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.thirdProduct);
            this.productStock.Add(this.forthProduct);

            Assert.That(() => this.productStock.FindAllByPrice(price),
                Throws.ArgumentException.With.Message.EqualTo("The given price cannot be less than zero!"));
        }

        [Test]
        public void FindAllByQuantityShouldReturnCollectionWithAllTheProductsWithTheGivenQuantity()
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);
            this.productStock.Add(this.thirdProduct);
            this.productStock.Add(this.forthProduct);

            List<IProduct> productsSortedByPrice = this.productStock.FindAllByQuantity(30).ToList();

            Assert.AreEqual(this.thirdProduct.Label, productsSortedByPrice[0].Label);
            Assert.AreEqual(this.thirdProduct.Price, productsSortedByPrice[0].Price);
            Assert.AreEqual(this.thirdProduct.Quantity, productsSortedByPrice[0].Quantity);

            Assert.AreEqual(this.forthProduct.Label, productsSortedByPrice[1].Label);
            Assert.AreEqual(this.forthProduct.Price, productsSortedByPrice[1].Price);
            Assert.AreEqual(this.forthProduct.Quantity, productsSortedByPrice[1].Quantity);
        }

        [Test]
        public void FindAllByQuantityShouldReturnCollectionWithTheCorrectCount()
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);
            this.productStock.Add(this.thirdProduct);
            this.productStock.Add(this.forthProduct);

            List<IProduct> productsSortedByPrice = this.productStock.FindAllByQuantity(30).ToList();

            Assert.AreEqual(2, productsSortedByPrice.Count);
        }

        [Test]
        public void FindAllByQuantityShouldReturnEmptyIfThereNoProductsWithTheGivenQuantity()
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);
            this.productStock.Add(this.forthProduct);

            List<IProduct> productsSortedByQuantity = this.productStock.FindAllByQuantity(100).ToList();

            Assert.AreEqual(0, productsSortedByQuantity.Count);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void FindAllByQuantityShouldThrowExceptionWhenTheGivenQuantityIsLessThanZero(int quantity)
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.thirdProduct);
            this.productStock.Add(this.forthProduct);

            Assert.That(() => this.productStock.FindAllByQuantity(quantity),
                Throws.ArgumentException.With.Message.EqualTo("The given quantity cannot be less than zero!"));
        }

        [Test]
        public void FindAllInRangeShouldReturnCollectionWithAllTheProductsBetweenGivenPriceRange()
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);
            this.productStock.Add(this.thirdProduct);
            this.productStock.Add(this.forthProduct);
            this.productStock.Add(this.fifthProduct);

            List<IProduct> productsSortedByPriceInRange = this.productStock.FindAllInRange(10, 20).ToList();

            Assert.AreEqual(this.secondProduct.Label, productsSortedByPriceInRange[0].Label);
            Assert.AreEqual(this.secondProduct.Price, productsSortedByPriceInRange[0].Price);
            Assert.AreEqual(this.secondProduct.Quantity, productsSortedByPriceInRange[0].Quantity);

            Assert.AreEqual(this.thirdProduct.Label, productsSortedByPriceInRange[1].Label);
            Assert.AreEqual(this.thirdProduct.Price, productsSortedByPriceInRange[1].Price);
            Assert.AreEqual(this.thirdProduct.Quantity, productsSortedByPriceInRange[1].Quantity);

            Assert.AreEqual(this.forthProduct.Label, productsSortedByPriceInRange[2].Label);
            Assert.AreEqual(this.forthProduct.Price, productsSortedByPriceInRange[2].Price);
            Assert.AreEqual(this.forthProduct.Quantity, productsSortedByPriceInRange[2].Quantity);
        }

        [Test]
        public void FindAllInRangeShouldReturnCollectionWithTheCorrectCount()
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);
            this.productStock.Add(this.thirdProduct);
            this.productStock.Add(this.forthProduct);

            List<IProduct> productsSortedByPrice = this.productStock.FindAllInRange(10, 20).ToList();

            Assert.AreEqual(3, productsSortedByPrice.Count);
        }

        [Test]
        public void FindAllInRangeShouldReturnEmptyIfThereNoProductsWithTheGivenPrice()
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.thirdProduct);
            this.productStock.Add(this.forthProduct);

            List<IProduct> productsSortedByPrice = this.productStock.FindAllInRange(31, 100).ToList();

            Assert.AreEqual(0, productsSortedByPrice.Count);
        }

        [TestCase(-5, -1)]
        [TestCase(-10, -20)]
        public void FindAllInRangeShouldThrowExceptionWhenTheGivenPriceIsLessThanZero(double lo, double hi)
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.thirdProduct);
            this.productStock.Add(this.forthProduct);

            Assert.That(() => this.productStock.FindAllInRange(lo, hi),
                Throws.ArgumentException.With.Message.EqualTo("The price range cannot be less than zero!"));
        }

        [Test]
        public void FindByLabelShouldReturnTheRightProductByTheGivenLabel()
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            string labelToFind = "Zagorka";

            IProduct foundProduct = this.productStock.FindByLabel(labelToFind);

            Assert.AreEqual(this.secondProduct.Label, foundProduct.Label);
            Assert.AreEqual(this.secondProduct.Price, foundProduct.Price);
            Assert.AreEqual(this.secondProduct.Quantity, foundProduct.Quantity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByLabelShouldThrowExceptionWhenTheGivenLabelIsNullOrEmpty(string labelToFind)
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            Assert.That(() => this.productStock.FindByLabel(labelToFind),
                Throws
                .InvalidOperationException.With.Message
                .EqualTo("Product label cannot be null or empty!"));

        }

        [Test]
        public void FindMostExpensiveProductShouldReturnTheMostExpensiveOneThatIsFirstAdded()
        {
            AddMultipleProducts();

            IProduct mostExpensiveProduct = this.productStock.FindMostExpensiveProduct();

            Assert.AreEqual(fifthProduct.Label, mostExpensiveProduct.Label);
            Assert.AreEqual(fifthProduct.Price, mostExpensiveProduct.Price);
            Assert.AreEqual(fifthProduct.Quantity, mostExpensiveProduct.Quantity);
        }

        [Test]
        public void FindMostExpensiveProductShouldThrowExceptionWhenProductStockIsEmpty()
        {
            Assert.That(() => this.productStock.FindMostExpensiveProduct(),
                Throws.InvalidOperationException.With.Message.EqualTo("There are no products in stock!"));
            
        }

        [Test]
        public void GetEnumeratorShouldReturnAllProductsInRightInsertionOrder()
        {
            AddMultipleProducts();

            List<IProduct> productsInStock = this.productStock.ToList();

            Assert.AreEqual(firstProduct.Label, productsInStock[0].Label);
            Assert.AreEqual(secondProduct.Label, productsInStock[1].Label);
            Assert.AreEqual(thirdProduct.Label, productsInStock[2].Label);
            Assert.AreEqual(forthProduct.Label, productsInStock[3].Label);
            Assert.AreEqual(fifthProduct.Label, productsInStock[4].Label);
            Assert.AreEqual(sixthProduct.Label, productsInStock[5].Label);
        }

        [Test]
        public void IndexerGetShouldReturnCorrectProductByIndex()
        {
            this.productStock.Add(firstProduct);
            this.productStock.Add(secondProduct);

            IProduct productInProductStock = this.productStock[1];

            Assert.AreEqual(this.secondProduct.Label, productInProductStock.Label);
            Assert.AreEqual(this.secondProduct.Price, productInProductStock.Price);
            Assert.AreEqual(this.secondProduct.Quantity, productInProductStock.Quantity);
        }

        [TestCase(-1)]
        [TestCase(3)]
        public void IndexerGetShouldThrowExceptionIfTheGivenIndexIsOutOfRange(int index)
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            Assert.That(() => this.productStock[index],
                Throws.Exception.InstanceOf<System.IndexOutOfRangeException>()
                .With.Message.EqualTo("Index is out of range"));
        }


        [Test]
        public void IndexerSetShouldChangeProductCorrectly()
        {
            AddMultipleProducts();

            string label = "IPhone 20 Max";
            decimal price = 3000.00m;
            int quantity = 3;

            this.productStock[4] = new Product(label, price, quantity);

            IProduct productInStock = this.productStock.Find(4);

            Assert.AreEqual(productInStock.Label, label);
            Assert.AreEqual(productInStock.Price, price);
            Assert.AreEqual(productInStock.Quantity, quantity);
        }

        [TestCase(-1)]
        [TestCase(3)]
        public void IndexerSetShouldThrowExceptionIfTheGivenIndexIsOutOfRange(int index)
        {
            this.productStock.Add(this.firstProduct);
            this.productStock.Add(this.secondProduct);

            Assert.That(() => this.productStock[index],
                Throws.Exception.InstanceOf<System.IndexOutOfRangeException>()
                .With.Message.EqualTo("Index is out of range"));
        }

        private void AddMultipleProducts()
        {
            this.productStock.Add(firstProduct);
            this.productStock.Add(secondProduct);
            this.productStock.Add(thirdProduct);
            this.productStock.Add(forthProduct);
            this.productStock.Add(fifthProduct);
            this.productStock.Add(sixthProduct);
        }
    }
}
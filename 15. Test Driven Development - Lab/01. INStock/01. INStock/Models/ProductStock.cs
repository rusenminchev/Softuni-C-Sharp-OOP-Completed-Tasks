using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using INStock.Contracts;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            if (this.products.Any(p => p.Label == product.Label))
            {
                throw new InvalidOperationException("This product is already added");
            }

            this.products.Add(product);
        }

        public bool Remove(IProduct product)
        {

            if (this.Contains(product))
            {
                this.products.Remove(product);
                return true;
            }
        
            return false;
        }

        public bool Contains(IProduct product)
        {
            return this.products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.products.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            IProduct product = this.products.ToList()[index];
            return product;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            if (price < 0)
            { 
            throw new ArgumentException("The given price cannot be less than zero!");
            }
            
            List<IProduct> productsSortedByPrice = new List<IProduct>();

            decimal decimalPrice = (decimal)price;

            productsSortedByPrice = this.products.Where(p => p.Price == decimalPrice).ToList();

            return productsSortedByPrice;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("The given quantity cannot be less than zero!");
            }

            List<IProduct> productsSortedByQuantity = new List<IProduct>();

            productsSortedByQuantity = this.products.Where(p => p.Quantity == quantity).ToList();

            return productsSortedByQuantity;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            if (lo < 0 || hi < 0)
            {
                throw new ArgumentException("The price range cannot be less than zero!");
            }

            decimal decimalLo = (decimal)lo;
            decimal decimalHi = (decimal)hi;

            List<IProduct> productsSortedByPriceRange = new List<IProduct>();

            productsSortedByPriceRange = this.products
                .Where(p => p.Price >= decimalLo).ToList();

            productsSortedByPriceRange = productsSortedByPriceRange
               .Where(p => p.Price <= decimalHi).ToList();

            return productsSortedByPriceRange;
        }

        public IProduct FindByLabel(string label)
        {
            if (string.IsNullOrEmpty(label))
            {
                throw new InvalidOperationException("Product label cannot be null or empty!");
            }

            IProduct foundProduct = this.products.FirstOrDefault(p => p.Label == label);

            return foundProduct;
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (this.products.Count == 0)
            {
                throw new InvalidOperationException("There are no products in stock!");
            }

            IProduct mostExpensiveProduct = this.products
                .OrderByDescending(p => p.Price)
                .First();

            return mostExpensiveProduct;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return this.products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IProduct this[int index]
        {
            get
            {
               return this.Find(index);
            }
            set 
            {
                this.products[index] = value;
            }
        }
    }
}

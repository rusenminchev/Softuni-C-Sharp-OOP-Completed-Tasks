using ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShoppingSpree.Models
{
    

    public class Person
    {
        private const decimal MIN_MONEY_VALUE = 0m;

        private string name;
        private decimal money;
        private List<Product> productsList;

        private Person()
        {
            this.productsList = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;    
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (GlobalConstants.InvalidNameExeptionMessage);
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < MIN_MONEY_VALUE)
                {
                    throw new ArgumentException(GlobalConstants.InvalidAmountOfMoneyExeptionMessage);
                }
                this.money = value;
            }
        }
        public ReadOnlyCollection<Product> ProductList
        {
            get
            {
                return this.productsList.AsReadOnly();
            }
        }

        public void AddProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException
                    (string.Format(GlobalConstants.InsufficientAmountOfMoneyExeptionMessage,
                    this.Name, product.Name));                
            }
            this.Money -= product.Cost;
            this.productsList.Add(product);
        }

        public override string ToString()
        {
            if (this.productsList.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }   
                return $"{this.Name} - {string.Join(", ", ProductList)}"; 
        }  
    }
}

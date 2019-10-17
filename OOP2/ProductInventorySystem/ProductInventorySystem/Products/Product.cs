using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventorySystem.Products
{
    public abstract class Product
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Цената трябва да е положително число!");
                }
                price = value;
            }
        }

        public  Product (string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
            Stock = 1;
        }

        public void AddStock(int num)
        {
            Stock += num;
        }

        public decimal calculateTotal()
        {
            return Stock * price;
        }

        public string getTotal()
        {
            return $"Общата цена на всички артикули от продукта {Title} е: " + calculateTotal() + " лв.";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Product p = obj as Product;
            if ((object)p == null)
                return false;

            return (Title == p.Title) && (Description == p.Description) && (price == p.price);
        }

        public override string ToString()
        {
            string stockName = Stock > 1 ? "броя" : "брой";
            return $"{Title}, {Description},  {price} лв. - {Stock} {stockName}";
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInventorySystem.Products;

namespace ProductInventorySystem
{
    public class Inventory
    {
        private List<Product> items;
        public Inventory()
        {
            items = new List<Product>();
        }
        public void AddProduct (Product product)
        {
            if (!items.Contains(product))
            {
                items.Add(product);
            }
            else
            {
                int index = items.IndexOf(product);
                items[index].AddStock(1);
            }
        }
        public void AddStock (Product product, int stock)
        {
            if(items.Contains(product) &&  stock > 0)
            {
                int index = items.IndexOf(product);
                items[index].AddStock(stock);
            }
            else
            {
                Console.WriteLine("Такъв продукт не съществува или броят на артикулите е невалиден!\n");
            }
        }

        public string calculateTotalOfProduct(Product product)
        {
            return product.getTotal();
        }
        public decimal calculateTotal()
        {
            decimal sum = 0;
            foreach(Product item in items)
            {
                sum += item.calculateTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            string laptops = "Лаптопи\n",
                   smartphones = "Смартфони\n",
                   tvs = "Телевизори\n";
            
            foreach (Product item in items)
            {
                if(item is Laptop)
                {
                    laptops += "****" + item.ToString() + "\n";
                }else if(item is SmartPhone)
                {
                    smartphones += "====" + item.ToString() + "\n";
                }
                else
                {
                    tvs += "####" + item.ToString() + "\n";
                }
            }

            return laptops + smartphones + tvs; 
        }

        

        public void PrintShop()
        {
            Console.WriteLine(this.ToString());
        }
    }
}

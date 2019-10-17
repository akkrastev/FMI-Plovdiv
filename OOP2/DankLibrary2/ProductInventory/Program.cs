using ProductInventory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory 
{
    class Program
    {
        private static Inventory inventory = Inventory.Instance;
        static void Main(string[] args)
        {
            while(true)
            {
                PrintAll();
                Console.WriteLine("=========");
                Console.WriteLine("Available commands:");
                foreach(var comm in Commands.AvailableCommands)
                {
                    Console.Write($"{comm} ,");
                }
                Console.WriteLine("Enter a command: ");
                string command = Console.ReadLine();
                switch(command)
                {
                    case Commands.ADD_PRODUCT:
                        AddProductUI();
                        break;
                    case Commands.ADD_STOCK:
                        AddStockUI();
                        break;
                    case Commands.GET_INVENTORY_TOTAL:
                        GetInventoryTotalUI();
                        break;
                    case Commands.GET_PRODUCT_TOTAL:
                        GetProductTotalUI();
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
        }

        public static void AddProductUI() 
        {
            string[] types = new string[] { "Shirt", "Coat" };
            foreach(var type in types)
            {
                Console.Write($"{type} | ");
            }
            Console.WriteLine();
            Console.WriteLine("Product type: ");
            Console.ReadKey();
            string productType = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Price: ");
            double.TryParse(Console.ReadLine(), out double price);

            Console.WriteLine();
            Console.Write("Quantity: ");
            int.TryParse(Console.ReadLine(), out int quantity);

            Product product = null;

            switch(productType)
            {
                case "Shirt":
                    product = new Shirt(name, price, quantity);
                    break;
                case "Coat":
                    product = new Coat(name, price, quantity);
                    break;
                default:
                    break;
            }

            if(product==null)
            {
               // inventory.AddProduct(product);
                Console.WriteLine("Unsupported type!!");
            }
            else {
              //  Console.WriteLine("Unsupported type!!");
                inventory.AddProduct(product);
               
            } 
        }
       

        private static void AddStockUI()
        {
           
        }

        public static void GetProductTotalUI()
        {
           
        }

        public static void GetInventoryTotalUI()
        {
           
        }

        private static void PrintAll()
        {
           if (inventory.Products.Count == 0)
            {
                Console.WriteLine("No products have been added to the inventory yet!");
            }
            else
            {
               
            } 
        }
    }
}

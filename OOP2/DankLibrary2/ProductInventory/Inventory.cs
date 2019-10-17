using ProductInventory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    public class Inventory
    {
        private static Inventory _instance;

        public static Inventory Instance
        {
            get
            {
                if (_instance == null)  
                {
                    _instance = new Inventory();
                }
                return _instance;
            }
        }
        //tova moje bi  mi e  greshkata ot predniq put
        public List<Product> Products { get; private set; } 

        public Inventory() 
        {
            this.Products = new List<Product>();
        }

        
        public void AddProduct(Product product)
        {
            if (this.Products.Any(p =>
             { return p.Name == product.Name && p.GetType() != product.GetType();
             }))
            {
                Console.WriteLine($"The inventory already contains a product of Type {product.GetType().Name} called {product.Name}");
                Console.ReadKey();
            }
            else
            {
                this.Products.Add(product);
                SaveChanges();
            }
        }

        
        public int AddQuantity(int id, int quantity)
        {
            Product targetProduct = this.Products.FirstOrDefault(p => p.Id == id); 
            if(targetProduct!=null)
            {
                targetProduct.Quantity += quantity;   
                return targetProduct.Quantity;
            }
            Console.WriteLine("Requested product with id {id} does not exist");
            Console.ReadKey();
            return -1;
        }

       
        public double GetProductTotal(int id)
        {
            double productTotal = 0.0;
            Product targetProduct = this.Products.FirstOrDefault(p => p.Id == id); 
            if (targetProduct != null)
            {
                productTotal=targetProduct.Price*targetProduct.Quantity;  
                return productTotal;
            }
            Console.WriteLine("Requested product with id {id} does not exist");
            Console.ReadKey();
            return -1;
        }

        
        

        private void SaveChanges()
        {
            foreach(var product in Products.Where(p=> p.Id==0))
            {
                product.Id = Products.Max(p => p.Id) + 1;
            }
        }

    }
}

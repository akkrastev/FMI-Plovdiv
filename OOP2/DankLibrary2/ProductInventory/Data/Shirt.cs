using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Data
{
    public class Shirt : Product
    {
        public Shirt(string name, double price, int quantity)
            : base(name, price)  { }
    }
}

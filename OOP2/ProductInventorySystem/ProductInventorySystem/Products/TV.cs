using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventorySystem.Products
{
    class TV : Product 
    {
        public TV(string title, string description, decimal price) : base(title, description, price) { }
    }
}

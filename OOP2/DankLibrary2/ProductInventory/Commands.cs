using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory
{
    class Commands
    {
        public const string ADD_PRODUCT = "/add";
        public const string ADD_STOCK = "/addstock";
        public const string GET_PRODUCT_TOTAL = "/getproducttotal";
        public const string GET_INVENTORY_TOTAL = "/inventorytotal";

        public static IEnumerable<string> AvailableCommands = new List<string>()
        {
            ADD_PRODUCT,
            ADD_STOCK,
            GET_INVENTORY_TOTAL,
            GET_PRODUCT_TOTAL
        };
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Metodicheskyi_MAGAZIN
{
    class ShoppingCart
    {
        public int id { get; set; }
        public int capacity { get; set; } = 50;
        static public List<Product> listOfOrderItems { get; set; }
    }
}

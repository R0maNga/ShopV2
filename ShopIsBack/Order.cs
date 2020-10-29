using System;
using System.Collections.Generic;
using System.Text;

namespace Metodicheskyi_MAGAZIN
{
    class Order
    {
        public int id { get; set; }
        public int buyerId { get; set; }
        public DateTime dateOfOrder { get; set; }
        public static List<Product> listOfOrderItems { get; set; }
    }
}

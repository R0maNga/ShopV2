using System;
using System.Collections.Generic;
using System.Text;

namespace Metodicheskyi_MAGAZIN
{
    class Product
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public  string name { get; set; }
        public string description { get; set; }
        public string amount { get; set; }
        public int price { get; set; }
        public List<Order> listOfOrders { get; set; }
    }
}

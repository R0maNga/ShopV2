using System;
using System.Collections.Generic;
using System.Text;

namespace Metodicheskyi_MAGAZIN
{
    class Buyer
    {
        public int id { get; set; }
        public string role { get; set; } = "buyer";
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int phoneNumber { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime dateOfRegister { get; set; }
        public int shoppingCartId { get; set; }
        public List<Product> listOfOrders { get; set; }
    }
}
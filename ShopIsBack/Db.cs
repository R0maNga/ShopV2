using System;
using System.Collections.Generic;
using System.Text;

namespace Metodicheskyi_MAGAZIN
{
     class  Db
    {
        public static Buyer currentUser = new Buyer();
        public static Dictionary<string, Buyer> Users = new Dictionary<string, Buyer>();
        public static Manager currentManager = new Manager();
        public static Dictionary<string, Manager> Manager = new Dictionary<string, Manager>();
        public static List<Product> products = new List<Product>();
        public static List<Product> description = new List<Product>();
        public static List<Product> shoppingcart = new List<Product>();
        public static List<Product> orderlist = new List<Product>();
        static Db()
        {
            string[] defaultProducts = new string[5] { "ice", "meat", "milk", "cola", "lays" };
            string[] defaultProductsDescription = new string[5] { "info1", "info2", "info3", "info4", "info5" };
            
            int count = 0;
            foreach (string prod in defaultProducts)
            {
                products.Add(new Product() { name = prod, description = defaultProductsDescription[count] });
                count++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Metodicheskyi_MAGAZIN
{
    class Db
    {
        public static Buyer currentUser = new Buyer();
        public static Dictionary<string, Buyer> Users = new Dictionary<string, Buyer>();
        public static List<Product> products = new List<Product>();
        public static List<Product> description = new List<Product>();
        static Db()
        {
            string[] defaultProducts = new string[5] { "ice", "meat", "milk", "cola", "lays" };
            foreach (string prod in defaultProducts)
            {
                products.Add(new Product() { name = prod });
            }
            string[] defaultProductsDescription = new string[5] { "info1", "info2", "info3", "info4", "info5" };
            foreach (string descrip in defaultProductsDescription)
            {
                description.Add(new Product() { name = descrip });
            }
        }
    }
}

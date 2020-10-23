using System;
using System.Linq;

namespace Metodicheskyi_MAGAZIN
{
    class Program
    {
        static void Main(string[] args)
        {
            //Db.products.Add(new Product() { name = "bla-bla" });
            Shop Shop1 = new Shop();
            Shop1.InitShop("Dungeon");
        }
    }
}

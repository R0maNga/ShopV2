using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Metodicheskyi_MAGAZIN
{
    class Shop
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Product> listOfProducts { get; set; }

        public void InitShop(string name)
        {

            ShoppingCart cart = new ShoppingCart();
            Console.WriteLine($"Welcome to the {name}!");
            initEnterPage();


            void initEnterPage()
            {
                Console.WriteLine("--------------------------------\n--------------------------------\nPress 1 to Sign In\nPress 2 to Log In");
                string value = Console.ReadLine();
                switch (value)
                {
                    case "1":
                        singIn();
                        break;
                    case "2":
                        Regestration();
                        break;
                    default:
                        Console.WriteLine("Incorrect number");
                        initEnterPage();
                        break;
                }
            }

            void Regestration()
            {
                Console.WriteLine("Login: ");
                string login = Console.ReadLine();
                bool item = Db.Users.ContainsKey(login);
                if (!item)
                {
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();
                    Console.WriteLine($"Hello {login}");
                    createUser(login, password);
                    initMenu();
                }
                else
                {
                    Console.WriteLine("This user already exists");
                    initEnterPage();
                }
            }

            void createUser(string user, string password)
            {
                Buyer buyer = new Buyer();
                buyer.name = user;
                buyer.password = password.GetHashCode().ToString();
                Db.Users[user] = buyer;
                setCurrentUser(buyer);
            }

            void singIn()
            {
                Console.WriteLine("Login: ");
                string login = Console.ReadLine();
                bool item = Db.Users.ContainsKey(login);
                if (item)
                {
                    checkPassword(login);
                }
                else
                {
                    Console.WriteLine($"There is no user with login:{login}");
                    initEnterPage();
                }
            }

            void checkPassword(string login)
            {
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                bool isPasswordCorrect = Db.Users[login].password == password.GetHashCode().ToString();
                if (isPasswordCorrect)
                {
                    Console.WriteLine($"Hello {login}");
                    setCurrentUser(Db.Users[login]);
                    initMenu();
                }
                else
                {
                    Console.WriteLine("Wrong password. Try again");
                    checkPassword(login);
                }
            }


            void initMenu()
            {
                Console.WriteLine("--------------------------------\n--------------------------------\nMENU\n1 - Open product list\n2 - Open shopping cart\n3 - Open order list\n4 - Sing out");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        showProductList();
                        break;
                    case "2":
                        openShoppingCart();
                        break;
                    case "3":

                        break;
                    case "4":
                        singOut();
                        break;
                    default:
                        Console.WriteLine("Incorrect number");
                        initMenu();
                        break;
                }
            }

            void singOut()
            {
                Db.currentUser = null;
                initEnterPage();
            }

            void setCurrentUser(Buyer obj)
            {
                Db.currentUser = obj;
            }

            void showProductList()
            {
                int count = 0;
                foreach (Product prod in Db.products)
                {
                    count++;
                    Console.WriteLine($"{count} - {prod.name}");
                }
                string prodNum = Console.ReadLine();
                int prodNumInt = Convert.ToInt32(prodNum);
                showProductDescription(prodNumInt);
            }

            void showProductDescription(int prodNumInt)
            {
                Console.WriteLine($"name: {Db.products[prodNumInt - 1].name}\nACTIONS:\n 1 - Add to shopping cart\n 2 - Back to menu");
                string value = Console.ReadLine();
                switch (value)
                {
                    case "1":

                        break;
                    case "2":
                        initMenu();
                        break;
                    default:
                        Console.WriteLine("Incorrect number");
                        showProductDescription(prodNumInt);
                        break;
                }
            }

            void managerMenu()
            {
                Console.WriteLine("1-Add product to list\n2-Delete product from list\n3-Change product info");
                string key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        {
                            addNewProductToList();
                        }
                        break;
                    case "2":
                        {
                            deleteProduct();
                        }
                        break;
                    case "3":
                        {
                            changeProductInfo();
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Incorrect number");
                            managerMenu();
                        }
                        break;
                }
            }

            void addProductToShoppingCart()
            {
                var a = Db.products.Find(l => l.name == "lays");

                ShoppingCart.listOfOrderItems.Add(Order.listOfOrderItems);
            }
            void openShoppingCart()
            {
                Console.WriteLine(ShoppingCart.listOfOrderItems);
            }

            void deleteProduct()
            {
                //Db.products.RemoveAt();
            }

            void changeProductInfo()
            {

            }
            void addNewProductToList()
            {

            }
            void showDescriptionOfProducts()
            {
                foreach (Product describ in Db.description)
                {

                    Console.WriteLine($"{describ.name}");
                }
            }

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

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
            Console.WriteLine($"Welcome to the {name}!");
            initEnterPage();


            void initEnterPage()
            {
                Console.WriteLine("--------------------------------\n--------------------------------\nPress 1 to Sign In\nPress 2 to Regestration to User\nPress 3 to Regestration to Manager");
                string value = Console.ReadLine();
                switch (value)
                {
                    case "1":
                        singIn();
                        break;
                    case "2":
                        regestrationUser();
                        break;
                    case "3":
                        {

                            regestrationManager();
                        }
                        break;
                    default:
                        Console.WriteLine("Incorrect number");
                        initEnterPage();
                        break;
                }
            }

            void regestrationUser()
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
            void regestrationManager()
            {
                Console.WriteLine("Login: ");
                string loginManager = Console.ReadLine();
                bool item = Db.Users.ContainsKey(loginManager);
                if (!item)
                {
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();
                    Console.WriteLine($"Hello {loginManager}");
                    createManager(loginManager, password);
                    managerMenu();
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
            void createManager(string loginManager, string password)
            {
                Manager manager = new Manager();
                manager.name = loginManager;
                manager.password = password.GetHashCode().ToString();
                Db.Manager[loginManager] = manager;
                setCurrentManager(manager);
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
                        showOrderList();
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
            void setCurrentManager(Manager obj)
            {
                Db.currentManager = obj;
            }
            void showProductList()
            {
                printList(Db.products);
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
                        addProduct(prodNumInt, Db.shoppingcart);
                        break;
                    case "2":
                        managerMenu();
                        break;
                    default:
                        Console.WriteLine("Incorrect number");
                        showProductDescription(prodNumInt);
                        break;
                }
            }

            void managerMenu()
            {
                Console.WriteLine("1-Add product to list\n2-Delete product from list\n3-Show product list\n4-Show product description");
                string key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        {
                            addProductToList();
                        }
                        break;
                    case "2":
                        {
                            deleteProduct();
                        }
                        break;
                    case "3":
                        {
                            printList(Db.products);
                            managerMenu();
                        }
                        break;
                    case "4":
                        {
                            
                            managerMenu();
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

            void addProduct(int prodNumInt, List<Product> list)
            {
                
                list.Add(Db.products[prodNumInt - 1]);

                showProductDescription(prodNumInt);

            }
            void openShoppingCart()
            {
                printList(Db.shoppingcart);
                Console.WriteLine("Нажмите на цифру для добавления продукта в чек");
                var productNumb = Console.ReadLine();
                int productNumbInt = Convert.ToInt32(productNumb);

                Console.WriteLine("Choose amount");
                string amount = Console.ReadLine();

                Db.shoppingcart[productNumbInt - 1].amount = amount;
                Db.orderlist.Add(Db.shoppingcart[productNumbInt-1]);
               
                initMenu();
            }
            
            void deleteProduct()
            {
                printList(Db.products);
                Console.WriteLine("Введите какой продукт удалить");
                string numb=Console.ReadLine();
                int number = Convert.ToInt32(numb);
                Db.products.Remove(Db.products[number-1]);
                initMenu();
            }

            void adProduct(Product newProd)
            {
                Db.products.Add(newProd);
                initMenu();
            }
            void changeProductInfo(Product newProd)
            {
                Console.WriteLine("введите доп инфу");
                var description=Console.ReadLine();
                newProd.description = description;
                Db.products.Add(newProd);
                initMenu();
            }
            void addProductToList()
            {
                Product newProd = new Product();
                Console.WriteLine("Введите название продукта");
                var name =Console.ReadLine();
                newProd.name = name;
                Console.WriteLine("1-Поменять доп инфу\n2-Добавить продукт");
                var a=Console.ReadLine();
                switch (a)
                {
                    case "1":
                        {
                            changeProductInfo(newProd);
                            
                        }
                        break;
                    case "2":
                        {
                            adProduct(newProd);
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Не то число");
                        }
                        break;
                }
            }
           

            void showProductInfo(int valueInt)
            {
                Console.WriteLine($"amount: {Db.orderlist[valueInt - 1].amount}");
                Console.WriteLine($"description: {Db.orderlist[valueInt - 1].description}");
            }
            
            void printList(List<Product> list)
            {
                int count = 0;
                foreach (Product prod in list)
                {
                    count++;
                    Console.WriteLine($"{count} - {prod.name}");


                }
            }

            void showOrderList()
            {
                printList(Db.orderlist);
                var value = Console.ReadLine();
                int valueInt = Convert.ToInt32(value);
                showProductInfo(valueInt);

                initMenu();
                /*printList(Db.orderlist);
                var value = Console.ReadLine();
                int valueInt = Convert.ToInt32(product);

                initMenu();*/
            }

        }
    }
}

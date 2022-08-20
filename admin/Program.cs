using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin

{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Driver> drivers = new List<Driver>();
            List<Transport> transports = new List<Transport>();


            bool adminAccess = false;
            int driverIndex = -1;
            while (true)
            {
                Console.Clear();

                string loginResult = login(drivers, ref adminAccess, ref driverIndex);
                if (loginResult == null)
                {
                    Console.WriteLine("UserName of Password incorrect!");
                    Console.ReadKey();
                    continue;
                }
                while (true)
                {
                    bool logOut = false;

                    if (adminAccess)
                    {
                        menuAdmin();
                        int input = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        switch (input)
                        {
                            case 1:
                                addDrivers(ref drivers);
                                break;
                            case 2:
                                EditDrivers(ref drivers);
                                break;
                            case 3:
                                deleteDrivers(ref drivers);
                                break;
                            case 4:
                                printDrivers(drivers, transports, products);

                                break;
                            case 5:
                                addProdcts(ref products, ref drivers);
                                break;
                            case 6:
                                EditProducts(ref products);
                                break;
                            case 7:
                                deleteProducts(ref products);
                                break;
                            case 8:
                                printProducts(products);
                                break;

                            case 9:
                                saleProducts(ref drivers, ref products, ref transports);
                                break;
                            case 10:
                                logOut = true;
                                break;
                            case 11:
                                return;
                            default:
                                Console.WriteLine("Try again!");
                                break;
                        }

                        if (logOut)
                        {
                            break;
                        }
                    }
                    else
                    {
                        menuDriver();
                        int input1 = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        switch (input1)
                        {
                            case 1:
                                showTodayTransport(ref transports, ref products, driverIndex);
                                Console.ReadKey();
                                break;
                            case 2:
                                logOut = true;
                                break;
                            case 3:
                                return;
                            default:
                                Console.WriteLine("Try Again");
                                break;
                        }
                        if (logOut)
                        {
                            break;
                        }
                    }
                }
            }
        }
        static string login(List<Driver> drivers, ref bool adminAccess, ref int driverIndex)
        {
            Console.Clear();
            List<User> users = new List<User>();
            User admin = new User("admin", "123", true);
            users.Add(admin);
            Console.WriteLine("Etner user name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName == userName && users[i].Password == password)
                {
                    adminAccess = true;
                    return "admin";
                }
            }
            for (int i = 0; i < drivers.Count; i++)
            {
                if (drivers[i].DriverSurName == userName && drivers[i].Password == password)
                {
                    adminAccess = false;
                    driverIndex = i;
                    return "driver";
                }
            }
            return null;
        }
        static void menuAdmin()
        {
            Console.Clear();

            Console.WriteLine("1) Add Driver");
            Console.WriteLine("2) Edit Driver");
            Console.WriteLine("3) Delete Driver");
            Console.WriteLine("4) Print Driver");
            Console.WriteLine("----------");
            Console.WriteLine("5) Add Products");
            Console.WriteLine("6) Edit Products");
            Console.WriteLine("7) Delete Products");
            Console.WriteLine("8) Print Products");
            Console.WriteLine("----------");
            Console.WriteLine("9) Sale product");
            Console.WriteLine("----------");
            Console.WriteLine("10) log Out");
            Console.WriteLine("11) Exit");

        }
        static void menuDriver()
        {
            Console.Clear();
            Console.WriteLine("1)Today Transport");
            Console.WriteLine("----------");
            Console.WriteLine("2)log Out");
            Console.WriteLine("3)Exit");


        }
        static void addProdcts(ref List<Product> products, ref List<Driver> drivers)
        {
            Console.WriteLine("Enter Product Id:");
            string ProductId = Console.ReadLine();

            Console.WriteLine("Enter Product Barcode:");
            string ProductBarcode = Console.ReadLine();

            Console.WriteLine("Enter Product Name:");
            string ProductName = Console.ReadLine();


            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id.IndexOf(ProductId) > -1 || products[i].Barcode.IndexOf(ProductBarcode) > -1 || products[i].Name.IndexOf(ProductName) > -1)
                {
                    Console.WriteLine("Product exist!");
                    Console.ReadKey();
                    return;
                }
            }

            Product product = new Product(ProductId, ProductBarcode, ProductName);
            products.Add(product);
        }
        static void EditProducts(ref List<Product> data)
        {
            Console.Clear();
            Console.WriteLine("Enter search:");
            string search = Console.ReadLine();

            int index = findProducts(data, search);
            if (index > -1)
            {
                Console.WriteLine("Enter new Id");
                data[index].Id = Console.ReadLine();

                Console.WriteLine("Enter new Barcode");
                data[index].Barcode = Console.ReadLine();
                Console.WriteLine("Enter new name:");
                data[index].Name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Edited!");
            }
            Console.ReadKey();

        }
        static int findProducts(List<Product> data, string search)
        {
            Console.Clear();
            int index = -1;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Id.IndexOf(search) != -1 || data[i].Name.IndexOf(search) != -1 || data[i].Barcode.IndexOf(search) != -1)

                { index = i; }
            }

            return index;
        }
        static void deleteProducts(ref List<Product> data)
        {
            Console.Clear();
            Console.WriteLine("Enter search");
            string search = Console.ReadLine();
            int index = findProducts(data, search);
            if (index > -1)
            {
                data[index].DeActive();
                Console.WriteLine("product deleted!");
                Console.ReadKey();
            }
        }
        static void printProducts(List<Product> data)
        {
            Console.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Exist())
                {
                    Console.WriteLine(data[i].Id);
                    Console.WriteLine(data[i].Barcode);
                    Console.WriteLine(data[i].Name);
                    Console.WriteLine("******");
                }
            }
            Console.ReadKey();
        }
        static void addDrivers(ref List<Driver> data)
        {
            Console.WriteLine("Enter driver name:");
            string driverName = Console.ReadLine();

            Console.WriteLine("Enter driver SurName:");
            string driverSurName = Console.ReadLine();

            Console.WriteLine("Enter CarType:");
            string carType = Console.ReadLine();

            Console.WriteLine("Enter CarNumber:");
            string carNumber = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            Driver drivers = new Driver(driverName, driverSurName, carType, carNumber, password);
            data.Add(drivers);

        }
        static void printDrivers(List<Driver> driver, List<Transport> transports, List<Product> produtcs)
        {
            Console.Clear();
            for (int i = 0; i < driver.Count; i++)
            {
                if (driver[i].Exist())
                {
                    Console.WriteLine(driver[i].DriverName);
                    Console.WriteLine(driver[i].DriverSurName);
                    Console.WriteLine(driver[i].CarType);
                    Console.WriteLine(driver[i].CarNumber);
                    Console.WriteLine();
                    showTodayTransport(ref transports, ref produtcs, i);
                    Console.WriteLine("**************************************************\n");
                }
            }
            Console.ReadKey();
        }
        static int findDrivers(List<Driver> data, string search)
        {
            Console.Clear();
            int index = -1;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].CarNumber.IndexOf(search) > -1 || data[i].DriverSurName.IndexOf(search) > -1 || data[i].CarType.IndexOf(search) > -1)
                { index = i; }
            }
            return index;
        }
        static void EditDrivers(ref List<Driver> data)
        {
            Console.Clear();
            Console.WriteLine("Enter search:");
            string search = Console.ReadLine();

            int index = findDrivers(data, search);
            if (index > -1)
            {
                Console.WriteLine("Enter new DriverName");
                data[index].DriverName = Console.ReadLine();
                Console.WriteLine("Enter new SurName");
                data[index].DriverSurName = Console.ReadLine();
                Console.WriteLine("Enter new CarType:");
                data[index].CarType = Console.ReadLine();
                Console.WriteLine("Enter new CarNumber:");
                data[index].CarNumber = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Edited!");
            }
            Console.ReadKey();

        }
        static void deleteDrivers(ref List<Driver> data)
        {
            Console.Clear();
            Console.WriteLine("Enter search");
            string search = Console.ReadLine();
            int index = findDrivers(data, search);
            if (index > -1)
            {
                data[index].DeActive();
                Console.WriteLine("product deleted!");
                Console.ReadKey();
            }
        }
        static void saleProducts(ref List<Driver> drivers, ref List<Product> products, ref List<Transport> transports)
        {

            int maxProductPerDriver = 1;
            Console.Clear();
            Console.WriteLine("Enter searchProduct:");
            string searchProduct = Console.ReadLine();
            int indexProduct = findProducts(products, searchProduct);
            if (indexProduct > -1)
            {

                int[] transportPerDriver = new int[drivers.Count];

                for (int i = 0; i < transports.Count; i++)
                {
                    transportPerDriver[transports[i].IndexDriver]++;
                }
                int eligibleDriver = -1;
                for (int i = 0; i < transportPerDriver.Length; i++)
                {
                    if (transportPerDriver[i] < maxProductPerDriver)
                    {
                        eligibleDriver = i;
                        break;
                    }
                }

                if (eligibleDriver == -1)

                {
                    Console.WriteLine("No Driver Find to ship");
                }
                else
                {
                    Console.WriteLine("Enter Address For Shipping:");
                    string Address = Console.ReadLine();
                    Console.WriteLine($"Transport This Product To the Address by {drivers[eligibleDriver].DriverName} {drivers[eligibleDriver].DriverSurName}");
                    transports.Add(new Transport(indexProduct, eligibleDriver, Address));
                }

            }
            else
            {
                Console.WriteLine("The Product Not found(404!)");
            }

            Console.ReadKey();
        }
        static void showTodayTransport(ref List<Transport> transports, ref List<Product> products, int currentDriverIndex)
        {
            int count = 0;
            for (int i = 0; i < transports.Count; i++)
            {
                if (transports[i].IndexDriver == currentDriverIndex)
                {


                    Product thePr = products[transports[i].IndexProduct];
                    Console.WriteLine($"Product ID:{thePr.Id} - Product Name:{thePr.Name} - Product Barcode:{thePr.Barcode} ");
                    Console.WriteLine("Address: " + transports[i].TransportAddress);
                    Console.WriteLine("");
                    count++;
                }
            }

            if (count == 0)
                Console.WriteLine("No Transport For this Driver");


        }

    }
}



using System;
using System.Collections.Generic;
using Food_Stall_Ordering_Menu;

namespace Food_Stall_Ordering_Menu
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Variation { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Order
    {
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }

        public Order()
        {
            Products = new List<Product>();
            Total = 0;
        }

        public void AddProduct(Product product)
        {
            Console.Clear();
            Products.Add(product);
            Total += product.Price;
            Console.Clear();
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
            Total -= product.Price;
            Console.Clear();
        }

        public void PayOrder()
        {
            Console.Clear();
            Console.WriteLine("\n\n         JEYLO'S FOOD STALL   ");
            Console.WriteLine("  >-----------------------------<  ");
            Console.WriteLine("   Order Details:\n\n");
            foreach (var product in Products)
            {
                Console.WriteLine($"   {product.Name} ({product.Variation}) - P{product.Price}");
            }
            Console.WriteLine($"\n   Total: P{Total}");
            Console.WriteLine("  >-----------------------------<  ");
            Console.WriteLine("      Thank You For Buying!");
            Console.WriteLine("        Have A Great Day!");

            Products.Clear();
            Total = 0;

            Console.Write("\n\nPress Any Key To Proceed.");
            Console.ReadLine();
            Console.Clear();
        }

        public void CancelOrder()
        {
            Total = 0;
            Console.Clear();
        }

        public void DisplayOrder()
        {
            Console.Clear();
            Console.WriteLine("\n\n         JEYLO'S FOOD STALL   ");
            Console.WriteLine("  >-----------------------------<  ");
            Console.WriteLine("   Order Summary:\n\n");
            foreach (var product in Products)
            {
                Console.WriteLine($"   {product.Name} ({product.Variation}) - P{product.Price}");
            }
            Console.WriteLine($"\n   Total: P{Total}");
            Console.WriteLine("  >-----------------------------<  ");
            Console.Write("\n\nPress Any Key To Proceed.");
            Console.ReadLine();
            Console.Clear();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();

            var products = new[]
            {
                new Product("Burger", 30.00m) { Variation = "Chicken" },
                new Product("Burger", 45.00m) { Variation = "Pork" },
                new Product("Burger", 60.00m) { Variation = "Beef" },

                new Product("Hotdog", 28.00m) { Variation = "Small" },
                new Product("Hotdog", 48.00m) { Variation = "Medium" },
                new Product("Hotdog", 78.00m) { Variation = "Large" },

                new Product("Fries", 20.00m) { Variation = "Small" },
                new Product("Fries", 35.00m) { Variation = "Medium" },
                new Product("Fries", 65.00m) { Variation = "Large" },

                new Product("Drinks", 12.00m) { Variation = "Yakult" },
                new Product("Drinks", 15.00m) { Variation = "Water" },
                new Product("Drinks", 18.00m) { Variation = "C2" },
                new Product("Drinks", 22.00m) { Variation = "Sting" },
                new Product("Drinks", 22.00m) { Variation = "Pepsi" },
                new Product("Drinks", 22.000m) { Variation = "Coca-Cola" },
                new Product("Drinks", 25.00m) { Variation = "Mountain Dew" },
            };

            while (true)
            {
                Console.WriteLine("\n\n   WELCOME TO JEYLO'S FOOD STALL   ");
                Console.WriteLine("  >-----------------------------<  \n");

                Console.WriteLine("   1. Add Product");
                Console.WriteLine("   2. View Order");
                Console.WriteLine("   3. Pay Order");
                Console.WriteLine("   4. Cancel Order");
                Console.WriteLine("   5. Exit");

                Console.WriteLine("\n  >-----------------------------<  ");

                Console.Write("   Choose an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddProduct(order, products);
                        break;
                    case "2":
                        order.DisplayOrder();
                        break;
                    case "3":
                        order.PayOrder();
                        Console.WriteLine("   ORDER PAID");
                        break;
                    case "4":
                        order.CancelOrder();
                        Console.WriteLine("   ORDER CANCELLED.");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Please choose again.");

                        Console.Write("\n\nPress Any Key To Proceed.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        static void AddProduct(Order order, Product[] products)
        {
            Console.Clear();
            Console.WriteLine("\n\n   WELCOME TO JEYLO'S FOOD STALL   ");
            Console.WriteLine("  >-----------------------------<  ");
            Console.WriteLine("   Available Products:\n\n");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"   {i + 1}. {products[i].Name} ({products[i].Variation}) - P{products[i].Price}");
            }
            Console.WriteLine("\n  >-----------------------------<  ");
            Console.Write("   Enter a product to add: ");
            var productNumber = Convert.ToInt32(Console.ReadLine()) - 1;

            if (productNumber >= 0 && productNumber < products.Length)
            {
                order.AddProduct(products[productNumber]);
                Console.WriteLine("   PRODUCT ADDED TO THE ORDER.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("   INVALID PRODUCT NUMBER.");
            }
        }
    }
}

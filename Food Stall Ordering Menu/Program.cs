using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using OrderingSystem;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Buffers.Text;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;

namespace OrderingSystem
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
            Console.WriteLine("   JEYLO'S FOOD STALL   ");
            Console.WriteLine("  >------------------<  \n\n");
            Console.WriteLine("Order Details:");
            foreach (var product in Products)
            {
                Console.WriteLine($"{product.Name} ({product.Variation}) - ₱{product.Price}");
            }
            Console.WriteLine($"\nTotal: ₱{Total}");
            Console.WriteLine("\nThank You For Buying!");
            Console.Write("\n\nPress Any Key To Proceed.");
            Console.ReadLine();
            Console.Clear();
        }

        public void CancelOrder()
        {
            Products.Clear();
            Total = 0;
            Console.Clear();
        }

        public void DisplayOrder()
        {
            Console.Clear();
            Console.WriteLine("Order Summary:\n");
            foreach (var product in Products)
            {
                Console.WriteLine($"{product.Name} ({product.Variation}) - ₱{product.Price}");
            }
            Console.WriteLine($"Total: ₱{Total}");
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
                new Product("Product 1", 10.99m) { Variation = "Small" },
                new Product("Product 1", 14.99m) { Variation = "Medium" },
                new Product("Product 1", 19.99m) { Variation = "Large" },

                new Product("Product 2", 9.99m) { Variation = "Red" },
                new Product("Product 2", 12.99m) { Variation = "Blue" },

                new Product("Product 3", 7.99m) { Variation = "Green" },
                new Product("Product 3", 10.99m) { Variation = "Yellow" },

                new Product("Product 4", 5.99m) { Variation = "Small" },
                new Product("Product 4", 8.99m) { Variation = "Medium" },

                new Product("Product 5", 3.99m) { Variation = "Single" },
                new Product("Product 5", 6.99m) { Variation = "Pack of 2" },
            };

            while (true)
            {

                Console.WriteLine("\n\n   WELCOME TO JEYLO'S FOOD STALL   ");
                Console.WriteLine("  >-----------------------------<  \n\n");

                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Order");
                Console.WriteLine("3. Pay Order");
                Console.WriteLine("4. Cancel Order");
                Console.WriteLine("5. Exit");

                Console.Write("\nChoose an option: ");
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
                        Console.WriteLine("Pay order");
                        break;
                    case "4":
                        order.CancelOrder();
                        Console.WriteLine("Order cancelled.");
                        break;
                    case "5":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nInvalid option. Please choose again.");

                        Console.Write("\n\nPress Any Key To Proceed.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AddProduct(Order order, Product[] products)
        {
            Console.Clear();
            Console.WriteLine("\nAvailable Products:");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} ({products[i].Variation}) - ₱{products[i].Price}");
            }

            Console.Write("\nEnter product number to add: ");
            var productNumber = Convert.ToInt32(Console.ReadLine()) - 1;

            if (productNumber >= 0 && productNumber < products.Length)
            {
                order.AddProduct(products[productNumber]);
                Console.WriteLine("Product added to order.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid product number.");
            }
        }
    }
}

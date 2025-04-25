using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeteriaOrderSystem
{
    class Program
    {
        // Delegate for order preparation
        public delegate void OrderPreparedEventHandler(string orderDetails);
        public static event OrderPreparedEventHandler OrderPrepared;

        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();

            orders.Add(new Order
            {
                CustomerName = "shri",
                PhoneNumber = "1234567890",
                Email = "shri@example.com",
                Drink = "Tea",
                Quantity = 2,
                Size = "Medium",
                MilkType = "Whole",
                Sugar = 2,
                Flavor = "None",
                Status = "Pending"
            });

            string[] owners = { "admin" }; 
            string ownerPassword = "admin123";

            try
            {
                string username, password;

                bool running = true;
                while (running)
                {
                    Console.WriteLine("=== Welcome to the Cafeteria Order System ===");
                    Console.WriteLine("1. Login as Admin");
                    Console.WriteLine("2. Login as User");
                    Console.WriteLine("3. Exit");
                    Console.Write("Choose an option (1/2/3): ");
                    int mainMenuChoice = int.Parse(Console.ReadLine());

                    switch (mainMenuChoice)
                    {
                        case 1: 
                            Console.WriteLine("Enter your username:");
                            username = Console.ReadLine();

                            Console.WriteLine("Enter your password:");
                            password = Console.ReadLine();

                            if (Array.Exists(owners, owner => owner == username) && password == ownerPassword)
                            {
                                Console.WriteLine("Welcome Admin! You can now view and manage orders.");
                                AdminViewAndManageOrders(orders);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Admin credentials. Please try again.");
                            }
                            break;

                        case 2: 
                            Console.WriteLine("Welcome, User! Please enter your details to place an order.");
                            UserOrderFlow(orders);
                            break;

                        case 3: 
                            running = false;
                            Console.WriteLine("Exiting the system. Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please choose 1, 2, or 3.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void UserOrderFlow(List<Order> orders)
        {
            try
            {
                User user = new User();
                user.CollectUserDetails(orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during user order flow: {ex.Message}");
            }
        }

        public static void AdminViewAndManageOrders(List<Order> orders)
        {
            try
            {
                Admin admin = new Admin();
                bool continueManaging = true;

                while (continueManaging)
                {
                    Console.WriteLine("=== Admin Menu ===");
                    Console.WriteLine("1. View all orders");
                    Console.WriteLine("2. Update order status");
                    Console.WriteLine("3. Exit Admin panel");
                    Console.Write("Choose an option (1/2/3): ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            admin.ViewAllOrders(orders);
                            break;
                        case 2:
                            admin.UpdateOrderStatus(orders);
                            break;
                        case 3:
                            continueManaging = false;
                            Console.WriteLine("Exiting Admin panel.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while managing orders: {ex.Message}");
            }
        }

        public static void OrderPreparedHandler(string orderDetails)
        {
            Console.WriteLine(orderDetails); 
        }
    }
}

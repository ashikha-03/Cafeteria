using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeteriaOrderSystem
{
    public class Admin
    {
        public void ViewAllOrders(List<Order> orders)
        {
            Console.WriteLine("=== All Orders ===");

            // Using LINQ to filter orders with a certain status
            var pendingOrders = orders.Where(order => order.Status == "Pending").ToList();

            if (pendingOrders.Any())
            {
                foreach (var order in pendingOrders)
                {
                    Console.WriteLine($"Order for {order.CustomerName}:");
                    Console.WriteLine($"- Drink: {order.Drink}");
                    Console.WriteLine($"- Quantity: {order.Quantity}");
                    Console.WriteLine($"- Size: {order.Size}");
                    Console.WriteLine($"- Milk Type: {order.MilkType}");
                    Console.WriteLine($"- Sugar: {order.Sugar} tbsp");
                    Console.WriteLine($"- Flavor: {order.Flavor}");
                    Console.WriteLine($"- Status: {order.Status}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No pending orders.");
            }
        }

        public void UpdateOrderStatus(List<Order> orders)
        {
            Console.WriteLine("Enter the customer name whose order status you want to update:");
            string customerName = Console.ReadLine();

            // Using Predicate to find the order
            Predicate<Order> findOrder = order => order.CustomerName == customerName;
            var order = orders.Find(findOrder);

            if (order != null)
            {
                Console.WriteLine("Current order status: " + order.Status);
                Console.WriteLine("Enter new status (e.g., Pending, In Progress, Completed):");
                string newStatus = Console.ReadLine();
                order.Status = newStatus;
                Console.WriteLine("Order status updated.");
            }
            else
            {
                Console.WriteLine("Order not found for customer " + customerName);
            }
        }
    }
}

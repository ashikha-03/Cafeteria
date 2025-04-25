using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CafeteriaOrderSystem
{
    public class User
    {
        public void CollectUserDetails(List<Order> orders)
        {
            try
            {
                // Delegate for custom validation
                Func<string, bool> validatePhoneNumber = phoneNumber => new Regex(@"^\d{10}$").IsMatch(phoneNumber);
                Func<string, bool> validateEmail = email => new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").IsMatch(email);

                Console.WriteLine("Please enter your name:");
                string customerName = Console.ReadLine();

                string phoneNumber;
                while (true)
                {
                    Console.WriteLine("Please enter your phone number (10 digits):");
                    phoneNumber = Console.ReadLine();

                    if (validatePhoneNumber(phoneNumber))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid phone number format. Please try again.");
                    }
                }

                string email;
                while (true)
                {
                    Console.WriteLine("Please enter your email:");
                    email = Console.ReadLine();
                    if (validateEmail(email))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid email format. Please try again.");
                    }
                }

                Console.WriteLine("Welcome " + customerName + "! Please choose your drink:");
                Console.WriteLine("1. Tea");
                Console.WriteLine("2. Coffee");
                Console.WriteLine("3. Hot Chocolate");
                Console.Write("Enter the number of your choice (1/2/3): ");
                int drinkChoice = int.Parse(Console.ReadLine());

                string drink = drinkChoice switch
                {
                    1 => "Tea",
                    2 => "Coffee",
                    3 => "Hot Chocolate",
                    _ => "Invalid drink choice"
                };

                Console.WriteLine($"You selected: {drink}. Please enter the quantity:");
                int quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Choose your drink size:");
                Console.WriteLine("1. Small");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Large");
                string size = Console.ReadLine() switch
                {
                    "1" => "Small",
                    "2" => "Medium",
                    "3" => "Large",
                    _ => "Medium"
                };

                Console.WriteLine("What type of milk would you like?");
                Console.WriteLine("1. Whole Milk");
                Console.WriteLine("2. Skim Milk");
                Console.WriteLine("3. Almond Milk");
                string milkType = Console.ReadLine() switch
                {
                    "1" => "Whole Milk",
                    "2" => "Skim Milk",
                    "3" => "Almond Milk",
                    _ => "Whole Milk"
                };

                Console.WriteLine("How many tablespoons of sugar?");
                int sugar = int.Parse(Console.ReadLine());

                Console.WriteLine("Any flavor (Optional)? (e.g., Vanilla, Caramel, None):");
                string flavor = Console.ReadLine();

                Order newOrder = new Order
                {
                    CustomerName = customerName,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Drink = drink,
                    Quantity = quantity,
                    Size = size,
                    MilkType = milkType,
                    Sugar = sugar,
                    Flavor = flavor,
                    Status = "Pending"
                };

                orders.Add(newOrder);

                Console.WriteLine("Your order has been placed!");
                Program.OrderPreparedHandler($"Order prepared for {customerName}: {drink}, {quantity} {size} with {milkType} milk and {sugar} tbsp sugar.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while collecting details: {ex.Message}");
            }
        }
    }
}

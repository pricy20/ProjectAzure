using System;
using System.Collections.Generic;

public class User
{
    public string Username { get; set; }

    public User(string username)
    {
        Username = username;
    }
}

public class Admin : User
{
    public Admin(string username) : base(username) { }

    public void ManageProducts()
    {
        Console.WriteLine($"{Username} can manage products (add, remove, update).");
    }
}

public class Customer : User
{
    public Customer(string username) : base(username) { }

    public void MakePurchase()
    {
        Console.WriteLine($"{Username} can make a purchase.");
    }
}

public class Guest : User
{
    public Guest(string username) : base(username) { }

    public void BrowseProducts()
    {
        Console.WriteLine($"{Username} can browse products.");
    }
}

public class EcommercePlatform
{
    public void AuthenticateAndPerformAction(User user)
    {
        // Using 'as' to safely check and perform role-specific actions
        Admin admin = user as Admin;
        if (admin != null)
        {
            Console.WriteLine($"Welcome Admin, {admin.Username}!");
            admin.ManageProducts();
        }
        else
        {
            Customer customer = user as Customer;
            if (customer != null)
            {
                Console.WriteLine($"Welcome Customer, {customer.Username}!");
                customer.MakePurchase();  
            }
            else
            {
                Guest guest = user as Guest;
                if (guest != null)
                {
                    Console.WriteLine($"Welcome Guest, {guest.Username}!");
                    guest.BrowseProducts(); 
                }
                else
                {
                    Console.WriteLine("Unknown user type.");
                }
            }
        }

        Console.WriteLine(); 
    }
}

public class Program
{
    public static void Main()
    {
        User adminUser = new Admin("AliceAdmin");
        User customerUser = new Customer("BobCustomer");
        User guestUser = new Guest("CharlieGuest");

        EcommercePlatform platform = new EcommercePlatform();

        platform.AuthenticateAndPerformAction(adminUser);
        platform.AuthenticateAndPerformAction(customerUser);
        platform.AuthenticateAndPerformAction(guestUser);
    }
}


// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        string correctLogin = "admin";
        string correctPassword = "1234";

        int attempts = 0;

        while (attempts < 3)
        {
            Console.Write("Enter Login: ");
            string login = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (login == correctLogin && password == correctPassword)
            {
                Console.WriteLine("Login successful!");
                return;
            }

            attempts++;
            Console.WriteLine("Incorrect login or password! Attempts left: " + (3 - attempts));
        }

        Console.WriteLine("User rejected! Too many wrong attempts.");
    }
}

// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        int digits = 0, alphabets = 0;

        foreach (char ch in input)
        {
            if (char.IsDigit(ch))
                digits++;
            else if (char.IsLetter(ch))
                alphabets++;
        }

        Console.WriteLine("Number of Alphabets: " + alphabets);
        Console.WriteLine("Number of Digits: " + digits);
    }
}


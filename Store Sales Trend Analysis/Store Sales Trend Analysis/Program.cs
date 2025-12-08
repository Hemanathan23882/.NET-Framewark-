// See https://aka.ms/new-console-template for more information
using System;

class StoreSalesAnalysis
{
    static void Main()
    {
        Console.WriteLine("=== STORE SALES TREND ANALYSIS ===");

        Console.Write("Enter number of days in the month: ");
        int n = int.Parse(Console.ReadLine());

        int[] sales = new int[n];

        Console.WriteLine("\nEnter sales for each day:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Day {i + 1}: ");
            sales[i] = int.Parse(Console.ReadLine());
        }

        // Backup copy
        int[] backup = new int[n];
        Array.Copy(sales, backup, n);

        // Display original
        Console.WriteLine("\nOriginal Sales Data:");
        DisplayArray(sales);

        // Sorted Data
        int[] sorted = (int[])sales.Clone();
        Array.Sort(sorted);

        Console.WriteLine("\nSorted Sales Data:");
        DisplayArray(sorted);

        // Total, highest, lowest
        int total = 0, max = sales[0], min = sales[0];
        foreach (int s in sales)
        {
            total += s;
            if (s > max) max = s;
            if (s < min) min = s;
        }

        Console.WriteLine($"\nTotal Monthly Sales: {total}");
        Console.WriteLine($"Highest Single-Day Sales: {max}");
        Console.WriteLine($"Lowest Single-Day Sales: {min}");

        // Search
        Console.Write("\nEnter a sales value to search: ");
        int key = int.Parse(Console.ReadLine());

        bool found = Array.Exists(sales, x => x == key);
        Console.WriteLine(found ? "Sales value FOUND." : "Sales value NOT FOUND.");

        // Comparison with another dataset
        Console.WriteLine("\nEnter another set of sales data to compare:");
        int[] compareSet = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Value {i + 1}: ");
            compareSet[i] = int.Parse(Console.ReadLine());
        }

        bool equal = AreEqualArrays(sales, compareSet);
        Console.WriteLine(equal ? "\nBoth sales datasets ARE EQUAL."
                                : "\nSales datasets ARE NOT EQUAL.");

        Console.WriteLine("\nProgram Complete.");
    }

    static void DisplayArray(int[] arr)
    {
        foreach (int value in arr)
            Console.Write(value + " ");
        Console.WriteLine();
    }

    static bool AreEqualArrays(int[] a, int[] b)
    {
        if (a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++)
            if (a[i] != b[i]) return false;
        return true;
    }
}

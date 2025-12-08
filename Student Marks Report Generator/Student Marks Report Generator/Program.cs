// See https://aka.ms/new-console-template for more information
using System;

class StudentMarksReport
{
    static void Main()
    {
        Console.WriteLine("=== STUDENT MARKS REPORT GENERATOR ===");

        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        int[] marks = new int[n];

        Console.WriteLine("\nEnter marks of students:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Student {i + 1}: ");
            marks[i] = int.Parse(Console.ReadLine());
        }

        // Backup copy
        int[] backup = new int[n];
        Array.Copy(marks, backup, n);

        // Display original
        Console.WriteLine("\nOriginal Marks:");
        DisplayArray(marks);

        // Sorted marks
        int[] sorted = (int[])marks.Clone();
        Array.Sort(sorted);

        Console.WriteLine("\nSorted Marks:");
        DisplayArray(sorted);

        // Total, highest, lowest
        int total = 0, max = marks[0], min = marks[0];
        foreach (int m in marks)
        {
            total += m;
            if (m > max) max = m;
            if (m < min) min = m;
        }

        Console.WriteLine($"\nTotal Marks: {total}");
        Console.WriteLine($"Highest Mark: {max}");
        Console.WriteLine($"Lowest Mark: {min}");

        // Search
        Console.Write("\nEnter a mark to search: ");
        int key = int.Parse(Console.ReadLine());

        bool found = Array.Exists(marks, x => x == key);
        Console.WriteLine(found ? "Mark FOUND in the list." : "Mark NOT FOUND.");

        // Comparison with another dataset
        Console.WriteLine("\nEnter another set of marks to compare:");
        int[] compareSet = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Mark {i + 1}: ");
            compareSet[i] = int.Parse(Console.ReadLine());
        }

        bool equal = AreEqualArrays(marks, compareSet);
        Console.WriteLine(equal ? "\nBoth sets of marks ARE IDENTICAL."
                                : "\nThe two sets of marks ARE DIFFERENT.");

        Console.WriteLine("\nReport Complete.");
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

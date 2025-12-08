// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter n (matrix size): ");
        int n = int.Parse(Console.ReadLine());

        int[,] mat = new int[n, n];

        Console.WriteLine("Enter matrix elements:");
        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                mat[i, j] = int.Parse(row[j]);
            }
        }

        Console.WriteLine("Snake Pattern Output:");

        for (int i = 0; i < n; i++)
        {
            // Even row → left to right
            if (i % 2 == 0)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(mat[i, j] + " ");
            }
            else // Odd row → right to left
            {
                for (int j = n - 1; j >= 0; j--)
                    Console.Write(mat[i, j] + " ");
            }
        }
    }
}

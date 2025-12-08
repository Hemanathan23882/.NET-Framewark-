// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        // Read matrix size
        int n = int.Parse(Console.ReadLine());
        int[,] mat = new int[n, n];

        // Read matrix elements
        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                mat[i, j] = int.Parse(row[j]);
            }
        }

        int primarySum = 0;
        int secondarySum = 0;

        for (int i = 0; i < n; i++)
        {
            primarySum += mat[i, i];
            secondarySum += mat[i, n - 1 - i];
        }
        int result = Math.Abs(primarySum - secondarySum);

        Console.WriteLine(result);
    }
}
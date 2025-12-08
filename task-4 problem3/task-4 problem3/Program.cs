// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] mat = new int[n, n];

        // Read matrix
        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                mat[i, j] = int.Parse(row[j]);
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int temp = mat[i, j];
                mat[i, j] = mat[j, i];
                mat[j, i] = temp;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(mat[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}


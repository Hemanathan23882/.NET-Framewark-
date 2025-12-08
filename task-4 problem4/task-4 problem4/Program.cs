// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        string[] dims = Console.ReadLine().Split();
        int m = int.Parse(dims[0]); // rows
        int n = int.Parse(dims[1]); // columns

        int[,] mat = new int[m, n];

        // Read matrix
        for (int i = 0; i < m; i++)
        {
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                mat[i, j] = int.Parse(row[j]);
            }
        }

        PrintSpiral(mat, m, n);
    }

    static void PrintSpiral(int[,] mat, int m, int n)
    {
        int top = 0, bottom = m - 1;
        int left = 0, right = n - 1;

        while (top <= bottom && left <= right)
        {

            for (int i = left; i <= right; i++)
                Console.Write(mat[top, i] + " ");
            top++;

            for (int i = top; i <= bottom; i++)
                Console.Write(mat[i, right] + " ");
            right--;


            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                    Console.Write(mat[bottom, i] + " ");
                bottom--;
            }

            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                    Console.Write(mat[i, left] + " ");
                left++;
            }
        }
    }
}

// See https://aka.ms/new-console-template for more information
using System;

// --- Class Definition: Calculator ---
public class Calculator
{
    // --- Add Overloads ---

    // int Add(int a, int b)
    public int Add(int a, int b)
    {
        Console.WriteLine($"Adding two integers: {a} + {b}");
        return a + b;
    }

    // int Add(int a, int b, int c)
    public int Add(int a, int b, int c)
    {
        Console.WriteLine($"Adding three integers: {a} + {b} + {c}");
        return a + b + c;
    }

    // double Add(double a, double b)
    public double Add(double a, double b)
    {
        Console.WriteLine($"Adding two doubles: {a} + {b}");
        return a + b;
    }

    // double Add(double a, double b, double c)
    public double Add(double a, double b, double c)
    {
        Console.WriteLine($"Adding three doubles: {a} + {b} + {c}");
        return a + b + c;
    }

    // --- Multiply Overloads ---

    // int Multiply(int a, int b)
    public int Multiply(int a, int b)
    {
        Console.WriteLine($"Multiplying two integers: {a} * {b}");
        return a * b;
    }

    // int Multiply(int a, int b, int c)
    public int Multiply(int a, int b, int c)
    {
        Console.WriteLine($"Multiplying three integers: {a} * {b} * {c}");
        return a * b * c;
    }

    // double Multiply(double a, double b)
    public double Multiply(double a, double b)
    {
        Console.WriteLine($"Multiplying two doubles: {a} * {b}");
        return a * b;
    }

    // --- Subtract Overloads (Single and double variants) ---
    // C# uses 'float' for Single precision floating point types.

    // float Subtract(float a, float b) - Single variant
    public float Subtract(float a, float b)
    {
        Console.WriteLine($"Subtracting two Singles/Floats: {a} - {b}");
        return a - b;
    }

    // double Subtract(double a, double b) - Double variant
    public double Subtract(double a, double b)
    {
        Console.WriteLine($"Subtracting two doubles: {a} - {b}");
        return a - b;
    }
}

// --- Main Program Class ---
class Program
{
    static void Main(string[] args)
    {
        Calculator calc = new Calculator();

        Console.WriteLine("--- Testing Add Overloads ---");
        Console.WriteLine($"Result: {calc.Add(5, 10)}\n");
        Console.WriteLine($"Result: {calc.Add(5, 10, 2)}\n");
        // Suffix 'd' denotes a double literal
        Console.WriteLine($"Result: {calc.Add(5.5d, 10.2d)}\n");
        Console.WriteLine($"Result: {calc.Add(5.5d, 10.2d, 1.1d)}\n");

        Console.WriteLine("--- Testing Multiply Overloads ---");
        Console.WriteLine($"Result: {calc.Multiply(5, 10)}\n");
        Console.WriteLine($"Result: {calc.Multiply(5, 10, 2)}\n");
        Console.WriteLine($"Result: {calc.Multiply(5.5d, 10.2d)}\n");

        Console.WriteLine("--- Testing Subtract Overloads ---");
        // Suffix 'f' denotes a float (Single) literal
        Console.WriteLine($"Result: {calc.Subtract(20.5f, 10.2f)}\n");
        Console.WriteLine($"Result: {calc.Subtract(20.5d, 10.2d)}\n");
    }
}


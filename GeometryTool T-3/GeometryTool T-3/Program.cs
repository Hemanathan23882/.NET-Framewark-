// See https://aka.ms/new-console-template for more information
using System;

// --- Class Definition: GeometryTool ---
public class GeometryTool
{
    // 1. Overload for a Square (Perimeter = 4 * side)
    public double Perimeter(double side)
    {
        Console.WriteLine($"Calculating Perimeter of a Square with side {side}");
        return 4 * side;
    }

    // 2. Overload for a Rectangle (Perimeter = 2 * (length + breadth))
    public double Perimeter(double length, double breadth)
    {
        Console.WriteLine($"Calculating Perimeter of a Rectangle with length {length} and breadth {breadth}");
        return 2 * (length + breadth);
    }

    // 3. Overload for a Triangle (Perimeter = a + b + c)
    // Note: This assumes the sides form a valid triangle; we just sum them for perimeter.
    public double Perimeter(double a, double b, double c)
    {
        Console.WriteLine($"Calculating Perimeter of a Triangle with sides {a}, {b}, and {c}");
        return a + b + c;
    }

    // 4. Overload for a Circle (Perimeter/Circumference = 2 * PI * radius)
    // The boolean parameter 'isCircle' is used to differentiate this signature from the 'double side' signature, 
    // satisfying the requirement for unique method signatures.
    public double Perimeter(double radius, bool isCircle)
    {
        if (isCircle)
        {
            Console.WriteLine($"Calculating Circumference of a Circle with radius {radius}");
            // Use Math.PI constant for precision
            return 2 * Math.PI * radius;
        }
        else
        {
            // If the boolean was somehow used incorrectly, handle it gracefully
            throw new ArgumentException("The second parameter must be true to indicate a Circle calculation.");
        }
    }
}

// --- Main Program Class ---
class Program
{
    static void Main(string[] args)
    {
        GeometryTool tool = new GeometryTool();

        Console.WriteLine("--- Testing Perimeter Method Overloads ---");

        // Call Overload 1 (Square)
        double squarePerimeter = tool.Perimeter(5.0);
        Console.WriteLine($"Result: {squarePerimeter}\n");

        // Call Overload 2 (Rectangle)
        double rectanglePerimeter = tool.Perimeter(4.0, 10.0);
        Console.WriteLine($"Result: {rectanglePerimeter}\n");

        // Call Overload 3 (Triangle)
        double trianglePerimeter = tool.Perimeter(3.0, 4.0, 5.0); // A 3-4-5 right triangle
        Console.WriteLine($"Result: {trianglePerimeter}\n");

        // Call Overload 4 (Circle)
        // We pass 'true' for the required boolean differentiator
        double circleCircumference = tool.Perimeter(7.0, true);
        Console.WriteLine($"Result: {circleCircumference:F2}\n"); // Format to 2 decimal places for PI value
    }
}


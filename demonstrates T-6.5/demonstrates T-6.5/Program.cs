// See https://aka.ms/new-console-template for more information
using System;

// --- Base Class: Shape ---
public class Shape
{
    // 1 & 2. Define a virtual method that can be overridden by derived classes
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a shape (General/Base implementation)");
    }
}

// --- Derived Class: Circle (3) ---
public class Circle : Shape
{
    // 4. Override the Draw method with specific behavior
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
}

// --- Derived Class: Rectangle (3) ---
public class Rectangle : Shape
{
    // 4. Override the Draw method with specific behavior
    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle");
    }
}

// --- Derived Class: Triangle (3) ---
public class Triangle : Shape
{
    // 4. Override the Draw method with specific behavior
    public override void Draw()
    {
        Console.WriteLine("Drawing a triangle");
    }
}

// --- Main Program Class ---
class Program
{
    static void Main(string[] args)
    {
        // 5. Create a base class reference variable of type Shape.
        Shape currentShape;

        Console.WriteLine("--- Demonstrating Runtime Polymorphism (Method Overriding) ---");

        // Assign an object of Circle to the base class reference and call Draw()
        currentShape = new Circle();
        // The method executed is Circle.Draw() because the actual object is a Circle.
        currentShape.Draw();

        // Assign an object of Rectangle to the base class reference and call Draw()
        currentShape = new Rectangle();
        // The method executed is Rectangle.Draw() because the actual object is a Rectangle.
        currentShape.Draw();

        // Assign an object of Triangle to the base class reference and call Draw()
        currentShape = new Triangle();
        // The method executed is Triangle.Draw() because the actual object is a Triangle.
        currentShape.Draw();

        Console.WriteLine("\nThe method executed depends on the object *created* at runtime, not the reference type declared at compile time.");
    }
}


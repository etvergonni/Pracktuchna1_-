using System;

namespace Praktychna8;

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(string color, double radius) : base("Коло", color)
    {
        Radius = radius;
    }

    public override double CalculateArea() => Math.PI * Radius * Radius;

    public override double CalculatePerimeter() => 2 * Math.PI * Radius;

    public override string GetDescription() => $"Коло радіусом {Radius:F2}";

    public override void Resize(double factor) => Radius *= factor;

    public override void Draw()
    {
        Console.WriteLine($"( O )  Коло ({Color}), радіус {Radius:F2}");
    }
}

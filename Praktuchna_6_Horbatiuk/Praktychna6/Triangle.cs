using System;

namespace Praktychna6;

public class Triangle : Shape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(string color, double a, double b, double c) : base("Трикутник", color)
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }

    public override double CalculatePerimeter() => SideA + SideB + SideC;

    public override double CalculateArea()
    {
        double s = CalculatePerimeter() / 2;
        double underRoot = s * (s - SideA) * (s - SideB) * (s - SideC);
        return underRoot > 0 ? Math.Sqrt(underRoot) : 0;
    }

    public override string GetDescription() => $"Трикутник зі сторонами {SideA:F2}, {SideB:F2}, {SideC:F2}";

    public override void Resize(double factor)
    {
        SideA *= factor;
        SideB *= factor;
        SideC *= factor;
    }

    public override void Draw()
    {
        Console.WriteLine($" /\\   Трикутник ({Color}), сторони {SideA:F2}, {SideB:F2}, {SideC:F2}");
    }
}

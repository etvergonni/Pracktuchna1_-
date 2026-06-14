using System;

namespace Praktychna6;

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(string color, double width, double height) : base("Прямокутник", color)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea() => Width * Height;

    public override double CalculatePerimeter() => 2 * (Width + Height);

    public override string GetDescription() => $"Прямокутник {Width:F2} x {Height:F2}";

    public override void Resize(double factor)
    {
        Width *= factor;
        Height *= factor;
    }

    public override void Draw()
    {
        Console.WriteLine($"[    ]  Прямокутник ({Color}), {Width:F2} x {Height:F2}");
    }
}

using System;

namespace Praktychna6;

public class Square : Rectangle
{
    public Square(string color, double side) : base(color, side, side)
    {
        Name = "Квадрат";
    }

    public double Side => Width;

    public override string GetDescription() => $"Квадрат зі стороною {Width:F2}";

    public override void Draw()
    {
        Console.WriteLine($"[ ]  Квадрат ({Color}), сторона {Width:F2}");
    }
}

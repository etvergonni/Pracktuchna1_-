using System;

namespace Praktychna7;

public abstract class Shape : IResizable, IDrawable, IPrintable
{
    public string Name { get; set; }
    public string Color { get; set; }

    protected Shape(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public virtual double CalculateArea() => 0;

    public virtual double CalculatePerimeter() => 0;

    public abstract string GetDescription();

    public abstract void Resize(double factor);

    public virtual void Draw()
    {
        Console.WriteLine($"Малюю фігуру {Name} ({Color})");
    }

    public virtual string GetPrintInfo()
    {
        return $"{Name} [{Color}]: площа = {CalculateArea():F2}, периметр = {CalculatePerimeter():F2}";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Praktychna6;

public partial class StudentGroup
{
    public IEnumerable<Shape> GetAllShapes()
        => _members.OfType<Student>().SelectMany(s => s.Projects);

    public double GetTotalAreaOfAllShapes()
    {
        double total = 0;
        foreach (var shape in GetAllShapes())
            total += shape.CalculateArea();
        return Math.Round(total, 2);
    }

    public void DrawAllShapes()
    {
        var shapes = GetAllShapes().ToList();
        if (shapes.Count == 0)
        {
            Console.WriteLine("Фігур ще немає.");
            return;
        }
        foreach (var shape in shapes)
            shape.Draw();
    }

    public void ResizeAllShapes(double factor)
    {
        foreach (var shape in GetAllShapes())
            shape.Resize(factor);
    }

    public int ShapesCount => GetAllShapes().Count();
}

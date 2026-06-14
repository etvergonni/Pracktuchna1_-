using System;

namespace Praktychna7;

public readonly struct Point : IEquatable<Point>
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Equals(Point other) => X == other.X && Y == other.Y;

    public override bool Equals(object? obj) => obj is Point p && Equals(p);

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public static bool operator ==(Point a, Point b) => a.Equals(b);

    public static bool operator !=(Point a, Point b) => !a.Equals(b);

    public override string ToString() => $"({X}, {Y})";

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }
}

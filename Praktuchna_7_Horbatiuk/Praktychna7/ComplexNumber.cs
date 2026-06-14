using System;

namespace Praktychna7;

public readonly struct ComplexNumber : IEquatable<ComplexNumber>
{
    public double Real { get; }
    public double Imaginary { get; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public double Magnitude => Math.Sqrt(Real * Real + Imaginary * Imaginary);

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        => new(a.Real + b.Real, a.Imaginary + b.Imaginary);

    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        => new(a.Real - b.Real, a.Imaginary - b.Imaginary);

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        => new(a.Real * b.Real - a.Imaginary * b.Imaginary,
               a.Real * b.Imaginary + a.Imaginary * b.Real);

    public bool Equals(ComplexNumber other)
        => Real.Equals(other.Real) && Imaginary.Equals(other.Imaginary);

    public override bool Equals(object? obj) => obj is ComplexNumber c && Equals(c);

    public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

    public static bool operator ==(ComplexNumber a, ComplexNumber b) => a.Equals(b);

    public static bool operator !=(ComplexNumber a, ComplexNumber b) => !a.Equals(b);

    public override string ToString()
        => Imaginary >= 0 ? $"{Real:F2} + {Imaginary:F2}i" : $"{Real:F2} - {Math.Abs(Imaginary):F2}i";

    public void Deconstruct(out double real, out double imaginary)
    {
        real = Real;
        imaginary = Imaginary;
    }
}

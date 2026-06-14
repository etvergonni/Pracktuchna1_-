using System;

namespace Praktychna8;

public readonly struct GradeRecord : IEquatable<GradeRecord>
{
    public string Subject { get; }
    public double Grade { get; }
    public DateTime Date { get; }

    public GradeRecord(string subject, double grade, DateTime date)
    {
        Subject = subject;
        Grade = grade;
        Date = date;
    }

    public bool Equals(GradeRecord other)
        => Subject == other.Subject && Grade.Equals(other.Grade) && Date.Equals(other.Date);

    public override bool Equals(object? obj) => obj is GradeRecord g && Equals(g);

    public override int GetHashCode() => HashCode.Combine(Subject, Grade, Date);

    public static bool operator ==(GradeRecord a, GradeRecord b) => a.Equals(b);

    public static bool operator !=(GradeRecord a, GradeRecord b) => !a.Equals(b);

    public override string ToString() => $"{Subject}: {Grade:F1} ({Date:dd.MM.yyyy})";

    public void Deconstruct(out string subject, out double grade)
    {
        subject = Subject;
        grade = Grade;
    }
}

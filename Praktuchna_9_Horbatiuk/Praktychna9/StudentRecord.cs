using System;

namespace Praktychna9;

public readonly struct StudentRecord : IEquatable<StudentRecord>
{
    public string FullName { get; }
    public string RecordBookNumber { get; }
    public double AverageGrade { get; }

    public StudentRecord(string fullName, string recordBookNumber, double averageGrade)
    {
        FullName = fullName;
        RecordBookNumber = recordBookNumber;
        AverageGrade = averageGrade;
    }

    public bool Equals(StudentRecord other)
        => RecordBookNumber == other.RecordBookNumber
        && FullName == other.FullName
        && AverageGrade.Equals(other.AverageGrade);

    public override bool Equals(object? obj) => obj is StudentRecord r && Equals(r);

    public override int GetHashCode() => HashCode.Combine(FullName, RecordBookNumber, AverageGrade);

    public static bool operator ==(StudentRecord a, StudentRecord b) => a.Equals(b);

    public static bool operator !=(StudentRecord a, StudentRecord b) => !a.Equals(b);

    public override string ToString() => $"{FullName} (№{RecordBookNumber}), бал {AverageGrade:F2}";

    public void Deconstruct(out string fullName, out string recordBookNumber, out double averageGrade)
    {
        fullName = FullName;
        recordBookNumber = RecordBookNumber;
        averageGrade = AverageGrade;
    }
}

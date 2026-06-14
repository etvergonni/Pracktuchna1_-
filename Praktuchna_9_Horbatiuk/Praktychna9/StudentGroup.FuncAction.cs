using System;
using System.Linq;

namespace Praktychna9;

public partial class StudentGroup
{
    public void PerformOperationOnStudents(Func<Student, bool> predicate, Action<Student> action)
    {
        foreach (var s in GetAllStudents())
            if (predicate(s)) action(s);
    }

    public double CalculateMetric(Func<Student, double> metric)
    {
        var list = GetAllStudents();
        return list.Count == 0 ? 0 : list.Average(metric);
    }

    public string GenerateReport(Func<StudentGroup, string> reporter) => reporter(this);
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Praktychna7;

public partial class StudentGroup
{
    private Point[] _labSeats = Array.Empty<Point>();
    private GradeRecord[] _gradeHistory = Array.Empty<GradeRecord>();

    public StudentRecord[] GetAllRecords()
        => _members.OfType<Student>().Select(s => s.GetRecord()).ToArray();

    public void OptimizeStorage()
    {
        var students = _members.OfType<Student>().ToList();

        _labSeats = new Point[students.Count];
        for (int i = 0; i < students.Count; i++)
            _labSeats[i] = new Point(i / 5 + 1, i % 5 + 1);

        var history = new List<GradeRecord>();
        foreach (var s in students)
            foreach (var kvp in s.Journal.SubjectGrades)
                history.Add(new GradeRecord(kvp.Key, kvp.Value, DateTime.Now));
        _gradeHistory = history.ToArray();
    }

    public Point[] GetLabSeats() => _labSeats;

    public GradeRecord[] GetGradeHistory() => _gradeHistory;

    public int OptimizedRecordsCount => _labSeats.Length + _gradeHistory.Length;
}

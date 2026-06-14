using System;
using System.Collections.Generic;

namespace Praktychna9;

public class EventManager
{
    public event EventHandler<StudentEventArgs>? StudentAdded;
    public event EventHandler<StudentEventArgs>? StudentRemoved;
    public event EventHandler<GroupReportEventArgs>? ReportGenerated;

    private readonly List<string> _history = new();

    public void RaiseStudentAdded(object sender, Student student)
    {
        StudentAdded?.Invoke(sender, new StudentEventArgs(student, "Студента додано"));
        _history.Add($"[{DateTime.Now:HH:mm:ss}] Додано студента: {student.FullName}");
    }

    public void RaiseStudentRemoved(object sender, Student student)
    {
        StudentRemoved?.Invoke(sender, new StudentEventArgs(student, "Студента видалено"));
        _history.Add($"[{DateTime.Now:HH:mm:ss}] Видалено студента: {student.FullName}");
    }

    public void RaiseReportGenerated(object sender, string report)
    {
        ReportGenerated?.Invoke(sender, new GroupReportEventArgs(report));
        _history.Add($"[{DateTime.Now:HH:mm:ss}] Згенеровано звіт ({report.Length} символів)");
    }

    public IReadOnlyList<string> GetHistory() => _history;
}

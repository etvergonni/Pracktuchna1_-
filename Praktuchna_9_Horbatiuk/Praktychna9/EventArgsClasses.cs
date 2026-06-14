using System;

namespace Praktychna9;

public class StudentEventArgs : EventArgs
{
    public Student Student { get; }
    public string Message { get; }

    public StudentEventArgs(Student student, string message = "")
    {
        Student = student;
        Message = message;
    }
}

public class GroupReportEventArgs : EventArgs
{
    public string Report { get; }
    public DateTime GeneratedAt { get; }

    public GroupReportEventArgs(string report)
    {
        Report = report;
        GeneratedAt = DateTime.Now;
    }
}

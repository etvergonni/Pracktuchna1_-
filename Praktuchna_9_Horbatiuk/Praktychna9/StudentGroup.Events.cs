using System;

namespace Praktychna9;

public partial class StudentGroup
{
    public event EventHandler<StudentEventArgs>? StudentAdded;
    public event EventHandler<StudentEventArgs>? StudentRemoved;
    public event EventHandler<StudentEventArgs>? GradeChanged;

    public void AddStudentWithEvents(Student s)
    {
        AddStudent(s);
        StudentAdded?.Invoke(this, new StudentEventArgs(s, "Студента додано"));
    }

    public bool RemoveStudentWithEvents(string recordBookNumber)
    {
        var student = FindStudent(recordBookNumber);
        bool removed = RemoveStudent(recordBookNumber);
        if (removed && student != null)
            StudentRemoved?.Invoke(this, new StudentEventArgs(student, "Студента видалено"));
        return removed;
    }

    public void NotifyGradeChanged(Student s)
        => GradeChanged?.Invoke(this, new StudentEventArgs(s, "Оцінку змінено"));
}

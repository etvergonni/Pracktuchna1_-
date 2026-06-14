using System;

namespace Praktychna9;

public partial class Student
{
    public event EventHandler<StudentEventArgs>? AverageGradeChanged;

    public void ChangeAverageGrade(double newGrade)
    {
        UpdateAverageGrade(newGrade);
        AverageGradeChanged?.Invoke(this, new StudentEventArgs(this, $"Новий середній бал: {newGrade:F2}"));
    }
}

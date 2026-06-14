using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Praktychna9;

public class StudentDto
{
    public string FullName { get; set; } = string.Empty;
    public string RecordBookNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public double AverageGrade { get; set; }
    public int CourseProgress { get; set; }
    public string? Notes { get; set; }
}

public partial class StudentGroup
{
    public void Save(string filePath, StorageFormat format)
    {
        var fm = new FileManager();
        if (format == StorageFormat.Json)
        {
            var dtos = GetAllStudents().Select(s => new StudentDto
            {
                FullName = s.FullName,
                RecordBookNumber = s.RecordBookNumber,
                DateOfBirth = s.DateOfBirth,
                AverageGrade = s.AverageGrade,
                CourseProgress = s.CourseProgress,
                Notes = s.Notes
            }).ToList();
            fm.SaveToJson(dtos, filePath);
        }
        else
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Група: {GroupName}");
            sb.AppendLine($"Кількість студентів: {GetAllStudents().Count}");
            sb.AppendLine();
            foreach (var s in GetAllStudents())
                sb.AppendLine(s.GetFormattedInfo(true));
            fm.SaveToText(sb.ToString(), filePath);
        }
    }

    public static StudentGroup Load(string filePath, StorageFormat format)
    {
        if (format != StorageFormat.Json)
            throw new InvalidFileFormatException("Завантаження групи підтримується лише для формату JSON.");

        var fm = new FileManager();
        var dtos = fm.LoadFromJson<List<StudentDto>>(filePath);

        var group = new StudentGroup();
        foreach (var d in dtos)
        {
            var student = new Student(d.FullName, d.DateOfBirth, d.RecordBookNumber)
            {
                CourseProgress = d.CourseProgress,
                Notes = d.Notes
            };
            student.UpdateAverageGrade(d.AverageGrade);
            group.AddStudent(student);
        }
        return group;
    }

    public void ExportGradesToCsv(string filePath)
    {
        var fm = new FileManager();
        fm.ExportToCsv(this, filePath);
    }
}

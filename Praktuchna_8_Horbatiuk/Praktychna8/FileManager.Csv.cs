using System.IO;
using System.Text;

namespace Praktychna8;

public partial class FileManager
{
    public void ExportToCsv(StudentGroup group, string filePath)
    {
        EnsureDirectoryForFile(filePath);
        var sb = new StringBuilder();
        sb.AppendLine("ПІБ;Номер залікової;Середній бал");

        foreach (var s in group.GetAllStudents())
            sb.AppendLine($"{s.FullName};{s.RecordBookNumber};{s.AverageGrade:F2}");

        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
    }
}

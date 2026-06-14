using System;
using System.IO;

namespace Praktychna8;

public partial class StudentGroup
{
    // Варіант 2: імпорт студентів з CSV файлу.
    // Формат рядка: ПІБ;Номер залікової;Середній бал
    public int ImportStudentsFromCsv(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("CSV файл не знайдено.", filePath);

        string[] lines = File.ReadAllLines(filePath);
        int imported = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;

            // Пропускаємо рядок заголовка.
            if (i == 0 && line.Contains("ПІБ")) continue;

            string[] parts = line.Split(';');
            if (parts.Length < 2)
                continue;

            try
            {
                string fullName = parts[0].Trim();
                string recordBook = parts[1].Trim();
                double average = 0;
                if (parts.Length >= 3)
                    double.TryParse(parts[2].Trim(), out average);

                var student = new Student(fullName, new DateTime(2005, 1, 1), recordBook);
                student.UpdateAverageGrade(average);
                AddStudent(student);
                imported++;
            }
            catch (Exception)
            {
                // Пропускаємо рядок з некоректними даними.
            }
        }
        return imported;
    }
}

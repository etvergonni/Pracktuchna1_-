using System;
using System.IO;

namespace Praktychna8;

public partial class FileManager
{
    public void CreateBackup(string sourcePath)
    {
        if (!File.Exists(sourcePath))
            throw new FileNotFoundException("Файл для резервної копії не знайдено.", sourcePath);

        Directory.CreateDirectory("Backups");
        string name = Path.GetFileNameWithoutExtension(sourcePath);
        string ext = Path.GetExtension(sourcePath);
        string stamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string backupPath = Path.Combine("Backups", $"{name}_{stamp}{ext}");

        File.Copy(sourcePath, backupPath, true);
    }

    public void CleanOldBackups(int daysOld)
    {
        if (!Directory.Exists("Backups"))
            return;

        var cutoff = DateTime.Now.AddDays(-daysOld);
        foreach (string file in Directory.GetFiles("Backups"))
        {
            var info = new FileInfo(file);
            if (info.LastWriteTime < cutoff)
                info.Delete();
        }
    }
}

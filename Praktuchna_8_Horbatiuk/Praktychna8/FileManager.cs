using System;
using System.IO;

namespace Praktychna8;

public enum StorageFormat
{
    Json,
    Text
}

public partial class FileManager
{
    public void SaveToText(string content, string filePath)
    {
        EnsureDirectoryForFile(filePath);
        using var writer = new StreamWriter(filePath, false);
        writer.Write(content);
    }

    public string ReadFromText(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Файл не знайдено.", filePath);
        using var reader = new StreamReader(filePath);
        return reader.ReadToEnd();
    }

    public void EnsureDirectories()
    {
        Directory.CreateDirectory("Backups");
        Directory.CreateDirectory("Reports");
        Directory.CreateDirectory("Logs");
    }

    public string[] ListFiles(string directory)
    {
        if (!Directory.Exists(directory))
            return Array.Empty<string>();
        return Directory.GetFiles(directory);
    }

    public void CopyFile(string source, string destination, bool overwrite = true)
    {
        EnsureDirectoryForFile(destination);
        File.Copy(source, destination, overwrite);
    }

    public void MoveFile(string source, string destination)
    {
        EnsureDirectoryForFile(destination);
        File.Move(source, destination, true);
    }

    public void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }

    private void EnsureDirectoryForFile(string filePath)
    {
        string? dir = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(dir))
            Directory.CreateDirectory(dir);
    }
}

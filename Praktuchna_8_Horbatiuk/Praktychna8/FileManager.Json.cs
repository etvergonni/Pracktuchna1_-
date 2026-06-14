using System.IO;
using System.Text.Json;

namespace Praktychna8;

public partial class FileManager
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public void SaveToJson<T>(T data, string filePath)
    {
        EnsureDirectoryForFile(filePath);
        string json = JsonSerializer.Serialize(data, _jsonOptions);
        File.WriteAllText(filePath, json);
    }

    public T LoadFromJson<T>(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Файл не знайдено.", filePath);

        string json = File.ReadAllText(filePath);
        try
        {
            T? result = JsonSerializer.Deserialize<T>(json, _jsonOptions);
            if (result is null)
                throw new InvalidFileFormatException("Файл порожній або має невірний формат JSON.");
            return result;
        }
        catch (JsonException ex)
        {
            throw new InvalidFileFormatException("Невірний формат JSON у файлі.", ex);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace EXAM_4;

public static class JsonManager
{
    private const string DefaultFilePath = "crocodiles.json";

    // Optional: Method to set a custom file path
    public static void SetFilePath(string filePath)
    {
        FilePath = filePath;
    }

    // Optional: Method to get the current file path
    public static string GetFilePath()
    {
        return FilePath;
    }

    private static string FilePath = DefaultFilePath;

    // ...

    // Updated LoadCrocodiles method with exception handling
    public static List<Crocodile> LoadCrocodiles()
    {
        try
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Crocodile>>(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading crocodiles: {ex.Message}");
        }

        return new List<Crocodile>();
    }

    // Updated SaveCrocodiles method with exception handling
    public static void SaveCrocodiles(List<Crocodile> crocodiles)
    {
        try
        {
            string json = JsonSerializer.Serialize(crocodiles);
            File.WriteAllText(FilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving crocodiles: {ex.Message}");
        }
    }
}

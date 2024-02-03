using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace EXAM_4;

public static class JsonManager
{
    private const string DefaultFilePath = "crocodiles.json";
    
    public static void SetFilePath(string filePath)
    {
        FilePath = filePath;
    }
    
    public static string GetFilePath()
    {
        return FilePath;
    }

    private static string FilePath = DefaultFilePath;
    
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

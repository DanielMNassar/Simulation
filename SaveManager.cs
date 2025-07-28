
using UnityEngine;
using System.IO;

public static class SaveManager
{
    private static string saveFilePath = Application.persistentDataPath + "/savefile.json";

    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game saved to " + saveFilePath);
    }

    public static SaveData Load()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<SaveData>(json);
        }

        Debug.LogWarning("Save file not found. Returning new data.");
        return new SaveData(); // default
    }

    public static void DeleteSave()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }
    }
}

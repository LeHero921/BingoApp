using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveManager : MonoBehaviour
{
    #region Singelton
    private static SaveManager _instance;
    public static SaveManager Instance => _instance;

    private void Awake() {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public SaveFile debugSF;

    private string fileName = "savefile.json";
    private string FilePath => Path.Combine(Application.persistentDataPath, fileName);

    public void SaveGame(SaveFile data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(FilePath, json);
        Debug.Log($"✅ Savefile gespeichert: {FilePath}");
        debugSF = data;
    }

    // Laden
    public SaveFile LoadGame()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            SaveFile data = JsonUtility.FromJson<SaveFile>(json);
            Debug.Log("✅ Savefile geladen");
            debugSF = data;
            return data;
        }
        else
        {
            Debug.LogWarning("⚠️ Keine Save-Datei gefunden – neue wird erstellt.");
            SaveFile newData = new SaveFile();
            SaveGame(newData);
            return newData;
        }
    }

    // Teilen (Exportieren)
    public void ShareSaveFile()
    {
        if (File.Exists(FilePath))
        {
            new NativeShare()
                .AddFile(FilePath)
                .SetSubject("Mein Spielstand")
                .SetText("Hier ist mein Savegame.")
                .SetTitle("Save teilen")
                .Share();
        }
        else
        {
            Debug.LogWarning("⚠️ Keine Datei zum Teilen gefunden.");
        }
    }

    // Optional: Save löschen
    public void DeleteSave()
    {
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
            Debug.Log("🗑 Savefile gelöscht.");
        }
    }

    // Optional: Datei-Pfad ausgeben
    public void PrintSavePath()
    {
        Debug.Log("📂 Speicherort: " + FilePath);
    }
}
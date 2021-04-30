using System.Collections;
using System.IO;
using System;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Bson;
using UnityEngine.Localization.Settings;
using System.Collections.Generic;

public class SaveManager : MonoBehaviour
{

    public static List<ISave> SavableList = new List<ISave>();
    public static event Action<JObject> SettingLoad;
    public static JObject Data = new JObject();

    static SaveManager instance;
    string jsonSetting;
    static string gameData;

    private void Awake()
    {
        if (SaveManager.instance == null)
        {
            DontDestroyOnLoad(this);
            SaveManager.instance = this;

        }
        else
        {
            Destroy(this.gameObject);
        }

        jsonSetting = Path.Combine(Application.persistentDataPath, "Settings.json");
        gameData = Path.Combine(Application.persistentDataPath, "Data.bin");

        SettingsHolder.ToSet += LoadSetting;
    }

    IEnumerator Start()
    {
        // Wait for the localization system to initialize, loading Locales, preloading etc.
        yield return LocalizationSettings.InitializationOperation;

        LoadSetting();
    }

    public void LoadSetting()
    {
        if (!File.Exists(jsonSetting))
            return;

        JObject parsFile = JObject.Parse(File.ReadAllText(jsonSetting));
        SettingLoad?.Invoke(parsFile);
    }

    public void LoadData()
    {
        if (!File.Exists(gameData))
            return;

        using (var fs = File.OpenRead(gameData))
        {
            using (var reader = new BsonReader(fs))
            {
                var serializator = new JsonSerializer();

                Data = serializator.Deserialize<JObject>(reader);
                print(Data);
            }
        }

    }

    public void SaveData()
    {
        foreach (ISave x in SavableList)
            x.Save();

        using (var fs = File.Open(gameData, FileMode.OpenOrCreate))
        {
            using (BsonWriter writer = new BsonWriter(fs))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, Data);
            }
        }

    }

    public void ResetData()
    {
        print(gameData);
        File.Delete(gameData);
        NewGameData();
        print(Data);
    }
  

    public void NewGameData()
        => Data = new JObject();

}

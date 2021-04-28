using System.Collections;
using System.IO;
using System;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Bson;
using UnityEngine.Localization.Settings;

public class SaveManager : MonoBehaviour
{
    string jsonSetting;
    string gameData;

    public static event Action<JObject> SettingLoad;
    public static JObject Data = new JObject();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        jsonSetting = Path.Combine(Application.persistentDataPath, "Settings.json");
        gameData = Path.Combine(Application.persistentDataPath, "Data.bin");

        SettingsHolder.ToSet += LoadSetting;

        Data.Add(new JProperty("this", "sasi"));
    }

    IEnumerator Start()
    {
        // Wait for the localization system to initialize, loading Locales, preloading etc.
        yield return LocalizationSettings.InitializationOperation;

        LoadSetting();
        SaveData();
        LoadData();
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

                Data = (serializator.Deserialize<JObject>(reader));

                print(Data);
            }
        }

    }

    public void SaveData()
    {
        MemoryStream ms = new MemoryStream();
        using (BsonWriter writer = new BsonWriter(ms))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, Data);
        }
    }

}

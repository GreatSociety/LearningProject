using System.Collections;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using UnityEngine.Localization.Settings;

public class SaveManager : MonoBehaviour
{
    string jsonSetting;

    public static event Action<JObject> SettingLoad;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        jsonSetting = Path.Combine(Application.persistentDataPath, "Settings.json");
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

}

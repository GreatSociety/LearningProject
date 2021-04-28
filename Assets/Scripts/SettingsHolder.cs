using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Localization.Settings;

public class SettingsHolder : MonoBehaviour
{

    [SerializeField] Scrollbar audioListerSet;
    [SerializeField] Scrollbar audioBackSet;
    [SerializeField] Scrollbar audioSoundSet;
    [SerializeField] LangSelect langSet;

    string jsonSetting;

    public static event Action<float> ChangeL;
    public static event Action<float> ChangeB;
    public static event Action<float> ChangeS;

    public static event Action ToSet;

    void Awake()
    {
        jsonSetting = Path.Combine(Application.persistentDataPath, "Settings.json");
        SaveManager.SettingLoad += Set;
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        audioListerSet.onValueChanged.AddListener(ChangeListn);
        audioBackSet.onValueChanged.AddListener(ChangeBack);
        audioSoundSet.onValueChanged.AddListener(ChangeSound);

        yield return LocalizationSettings.InitializationOperation;

        // Call earler than LocalizationInit:
        // Two way to fix : GameManager Ienum or different method for set;
        ToSet?.Invoke();
    }

    private void OnDisable()
    {
        Save();
    }

    public void ChangeListn(float value)
    {
        ChangeL?.Invoke(value);
    }

    public void ChangeBack(float value)
    {
        ChangeB?.Invoke(value);
    }

    public void ChangeSound(float value)
    {
        ChangeS?.Invoke(value);
    }

    public void Save()
    {
        using (StreamWriter file = File.CreateText(jsonSetting))
        using (JsonTextWriter writer = new JsonTextWriter(file))
        {
            writer.Formatting = Formatting.Indented;

            writer.WriteStartObject();

            writer.WritePropertyName("AudioListerVolume");
            writer.WriteValue(audioListerSet.value);

            writer.WritePropertyName("AudioBackVolume");
            writer.WriteValue(audioBackSet.value);

            writer.WritePropertyName("AudioSoundVolume");
            writer.WriteValue(audioSoundSet.value);

            writer.WritePropertyName("Lang");
            writer.WriteValue(langSet.dropdown.value);

            writer.WriteEndObject();
        }
    }

    public void Set(JObject obj)
    {
        audioListerSet.value = (float)obj["AudioListerVolume"];
        audioBackSet.value = (float)obj["AudioBackVolume"];
        audioSoundSet.value = (float)obj["AudioSoundVolume"];
    }


}

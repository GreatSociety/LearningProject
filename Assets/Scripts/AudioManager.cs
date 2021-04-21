using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

public class AudioManager : MonoBehaviour, ISave
{
    float audioListerVolume = 1f;
    float audioBackVolume = 1f;
    float audioSoundVolume = 1f;

    public static event Action<float> VolumeChangeL;
    public static event Action<float> VolumeChangeB;
    public static event Action<float> VolumeChangeS;

    string jsonSave;


    private void Awake()
    {
        AudioBackground.audioBackAwake += GetBackVolume;
        AudioSound.audioSoundAwake += GetSoundVolume;
        AudioGeneral.audioListnerAwake += GetListnerVolume;

        SettingsHolder.ChangeL += SetListnerVolume;
        SettingsHolder.ChangeB += SetBackVolume;
        SettingsHolder.ChangeS += SetSoundVolume;

        jsonSave = Path.Combine(Application.persistentDataPath, "Settings.json");
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Write();
    }

    public void SetListnerVolume(float volume)
    {
        audioListerVolume = volume;
        GetListnerVolume();
    }
    public void SetBackVolume(float volume)
    {
        audioBackVolume = volume;
        GetBackVolume();
    }
    public void SetSoundVolume(float volume)
    {
        audioSoundVolume = volume;
        GetSoundVolume();
    }

    public void GetListnerVolume()
        => VolumeChangeL?.Invoke(audioListerVolume);
    public void GetBackVolume()
        => VolumeChangeB?.Invoke(audioBackVolume);
    public void GetSoundVolume()
        => VolumeChangeS?.Invoke(audioSoundVolume);

    public void Save()
    {
        throw new NotImplementedException();
    }

    private void Write()
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);

        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            writer.Formatting = Formatting.Indented;

            writer.WritePropertyName("audioListerVolume");
            writer.WriteValue(audioListerVolume);

            writer.WritePropertyName("audioBackVolume");
            writer.WriteValue(audioBackVolume);

            writer.WritePropertyName("audioSoundVolume");
            writer.WriteValue(audioSoundVolume);
        }


    }
}


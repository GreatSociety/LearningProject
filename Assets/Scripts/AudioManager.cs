
using UnityEngine;
using System;
using Newtonsoft.Json.Linq;


public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// This script need to rewriting, but i have no time for it now 
    /// </summary>
    float audioListerVolume = 1f;
    float audioBackVolume = 1f;
    float audioSoundVolume = 1f;

    public static event Action<float> VolumeChangeL;
    public static event Action<float> VolumeChangeB;
    public static event Action<float> VolumeChangeS;

    private void Awake()
    {
        AudioBackground.audioBackAwake += GetBackVolume;
        AudioSound.audioSoundAwake += GetSoundVolume;
        AudioGeneral.audioListnerAwake += GetListnerVolume;

        SettingsHolder.ChangeL += SetListnerVolume;
        SettingsHolder.ChangeB += SetBackVolume;
        SettingsHolder.ChangeS += SetSoundVolume;

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

}


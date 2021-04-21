using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AudioAbstarct : MonoBehaviour
{
    protected float volume = 1f;

    protected void Set(float volume)
    {
        this.volume = volume;
        GetComponent<AudioSource>().volume = volume;
    }
}

[RequireComponent(typeof(AudioSource))]
public abstract class AudioBackground : AudioAbstarct
{
    public static event Action audioBackAwake;

    private void Awake()
    {
        AudioManager.VolumeChangeB += Set;
        audioBackAwake?.Invoke();
    }

    private void OnDestroy()
    {
        AudioManager.VolumeChangeB -= Set;
    }
}

[RequireComponent(typeof(AudioSource))]
public abstract class AudioSound: AudioAbstarct
{
    public static event Action audioSoundAwake;

    private void Awake()
    {
        AudioManager.VolumeChangeS += Set;
        audioSoundAwake?.Invoke();
    }

    private void OnDestroy()
    {
        AudioManager.VolumeChangeS -= Set;
    }

}

[RequireComponent(typeof(AudioListener))]
public abstract class AudioGeneral: AudioAbstarct
{
    public static event Action audioListnerAwake;

    private void Awake()
    {
        AudioManager.VolumeChangeL += Set;
        audioListnerAwake?.Invoke();
    }

    private void OnDestroy()
    {
        AudioManager.VolumeChangeL -= Set;
    }

    new protected void Set(float volume)
    {
        this.volume = volume;
        AudioListener.volume = volume;
    }

}

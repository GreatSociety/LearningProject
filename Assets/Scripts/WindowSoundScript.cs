using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WindowSoundScript : AudioSound
{

    [SerializeField] WindowObjScript window;
    [SerializeField] AudioClip outWindowSound;

    AudioSource windowSoundMananger;

    void Start()
    {
        windowSoundMananger = GetComponent<AudioSource>();
        windowSoundMananger.clip = outWindowSound;
        windowSoundMananger.loop = true;

        window.Breaking += WindowBreak;
    }

    void WindowOpen()
    {
        if (!window.isBreak)
            windowSoundMananger.Play();
            
    }

    void WindowClose()
    {
        if (!window.isBreak)
            windowSoundMananger.Stop();
    }

    void WindowBreak()
    {
        windowSoundMananger.Play();
    }
}

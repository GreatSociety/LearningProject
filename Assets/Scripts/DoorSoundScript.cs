using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorSoundScript : AudioSound
{
    AudioSource doorSoundManager;

    [SerializeField] AudioClip doorOpen;
    [SerializeField] AudioClip doorClose;
    [SerializeField] AudioClip doorLocked;

    // Start is called before the first frame update
    void Start()
    {
        doorSoundManager = GetComponent<AudioSource>();
        //doorSoundManager.volume = base.volume; // Здесть нужна переменная от AudioManager которая будет задавать громкость. 
    }

    void doorOpenPlay()
    {
        doorSoundManager.PlayOneShot(doorOpen);
    }

    void doorClosePlay()
    {
        doorSoundManager.PlayOneShot(doorClose);
    }

    void doorLockedPlay()
    {
        doorSoundManager.PlayOneShot(doorLocked);
    }

}

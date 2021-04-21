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
        //doorSoundManager.volume = base.volume; // ������ ����� ���������� �� AudioManager ������� ����� �������� ���������. 
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SettingsHolder : MonoBehaviour
{

    [SerializeField] Scrollbar audioListerSet;
    [SerializeField] Scrollbar audioBackSet;
    [SerializeField] Scrollbar audioSoundSet;
    [SerializeField] LangSelect langSet;

    public static event Action<float> ChangeL;
    public static event Action<float> ChangeB;
    public static event Action<float> ChangeS;

    // Start is called before the first frame update
    void Start()
    {
        audioListerSet.onValueChanged.AddListener(ChangeListn);
        audioBackSet.onValueChanged.AddListener(ChangeBack);
        audioSoundSet.onValueChanged.AddListener(ChangeSound);
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
}

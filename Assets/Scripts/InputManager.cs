using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public static event Action<KeyCode> KeyDown;

    private KeyCode E = KeyCode.E;
    private KeyCode Q = KeyCode.Q;

    bool enabledMode = true;

    // Update is called once per frame
    void Update()
    {
        InputRead(enabledMode);
    }

    void Call(Action<KeyCode> thisEvent, KeyCode thisKey)
    {
        thisEvent?.Invoke(thisKey);
    }

    void InputRead(bool mode)
    {
        if (!mode)
            return;

        if (Input.GetKeyDown(E))
            Call(KeyDown, E);
        else if (Input.GetKeyDown(Q))
            Call(KeyDown, Q);
    }

    public void InputModeChange()
    {
        enabledMode = !enabledMode;
    }

}

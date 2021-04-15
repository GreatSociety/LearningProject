using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public static event Action<bool> KeyDownE;
    public static event Action<bool> KeyDownQ;

    private KeyCode E = KeyCode.E;
    private KeyCode Q = KeyCode.Q;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(E))
            Call(KeyDownE);
        else if (Input.GetKeyDown(Q))
            Call(KeyDownQ);

    }

    void Call(Action<bool> thisEvent)
    {
        thisEvent?.Invoke(true);
        print("Call");
    }
}

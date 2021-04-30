using System;
using UnityEngine;
using Photon.Pun;

public class InputNetwork : MonoBehaviourPunCallbacks
{
    public static event Action<KeyCode> KeyDown;

    private KeyCode E = KeyCode.E;
    private KeyCode Q = KeyCode.Q;
    private KeyCode Esc = KeyCode.Escape;

    bool enabledMode = true;

    // Update is called once per frame
    void Update()
    {
       if (photonView.IsMine)
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
        else if (Input.GetKeyDown(Esc))
        {
            Call(KeyDown, Esc);
        }
    }

    public void InputModeChange()
    {
        if (photonView.IsMine)
            enabledMode = !enabledMode;
    }
}

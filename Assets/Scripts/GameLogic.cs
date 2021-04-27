using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    private void Update()
    {
        Logic();
    }
    void Logic()
    {
        if (SmatphoneInputControl.IsAllowed)
            SafeSystemScript.isSafeVisible = true;

        if (SafeScript.Opened)
            DoorObjScript.IsOpen = true;
    }
}

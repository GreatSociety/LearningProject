using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObjScript : MonoBehaviour
{
    [SerializeField] public Animator doorAnim;

    // public cause we need in Game Manage Conroll this var/ We should write method to conrol animation with this var;
    public bool IsLocked = true;
    private string doorState = "Locked";

    private string doorControl = "Open";
    private bool doorControlState = true;

    private string tryParam = "Trying";

    private void Update()
    {
        // We Should write some interface
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        TryOpen();

        if (doorAnim.GetBool(doorState))
            return;

        doorControlState = !doorControlState;

        doorAnim.SetBool(doorControl, doorControlState);

    }

    private void TryOpen()
    {
        doorAnim.SetBool(tryParam, true);
    }

  


}

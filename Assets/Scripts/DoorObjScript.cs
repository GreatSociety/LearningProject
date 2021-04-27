using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObjScript : MonoBehaviour, ObjectInterface 
{
    [SerializeField] public Animator doorAnim;

    // public cause we need in Game Manage Conroll this var/ We should write method to conrol animation with this var;
    public static bool IsOpen = false;
    private string doorState = "Locked";

    private string doorControl = "Open";
    private bool doorControlState = true;

    private string tryParam = "Trying";


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



    public void Interactive(KeyCode key, Transform player)
    {
        if (key == KeyCode.E)
        {
            TryUnlock();
            OpenDoor();
        }
    }

    void TryUnlock()
    {
        if (IsOpen)
            doorAnim.SetBool(doorState, false);
    }
}

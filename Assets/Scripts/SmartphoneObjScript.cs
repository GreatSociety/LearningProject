using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartphoneObjScript : MonoBehaviour, ObjectInterface
{
    Transform Player;
    [SerializeField] SmartphoneButtonController PanelController;

    public bool onHand = false;

    private Vector3 startPos;
    private Quaternion startRot;

    private Vector3 offsetPos = new Vector3(0.6f, 0, 1f);
    private Quaternion offsetRot = Quaternion.Euler(160f, 180f, -180f);

    private void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    private void Handler(bool onHand)
    {
        if (onHand)
            Take();
        else
            Put();
                 
    }

    private void Take()
    {
        transform.SetParent(Player);
        transform.localPosition = offsetPos;
        transform.localRotation = offsetRot;

    }
    private void Put()
    {
        transform.SetParent(null);
        transform.position = startPos;
        transform.rotation = startRot;
    }

    public void Interactive(KeyCode key, Transform player)
    {

        Player = player;

        if(key == KeyCode.E)
            onHand = !onHand;
            Handler(onHand);

        if (onHand && key == KeyCode.Q)
            PanelController.Unlock();

        if (!onHand && key == KeyCode.E)
            PanelController.ToWorkPanel();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetwork : MonoBehaviourPunCallbacks
{
    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;

    // Start is called before the first frame update
    void Awake()
    {
        if (photonView.IsMine)
        {
            PlayerNetwork.LocalPlayerInstance = this.gameObject;
        }
        else
        {
            //Destroy(gameObject.GetComponent<FPSNetwork>());
            Destroy(gameObject.GetComponent<InputNetwork>());
            Destroy(gameObject.GetComponent<AudioListener>());
            Destroy(gameObject.GetComponentInChildren<Camera>());

        }
    }
}

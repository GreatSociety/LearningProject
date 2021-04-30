using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    [Tooltip("The prefab to use for representing the player")]
    public GameObject playerPrefab;

    [Tooltip("The prefab to use for representing the player in single")]
    public GameObject playerPrefabSingle;

    public static GameManager gameManager;

    private void Start()
    {
        gameManager = this;

        if (playerPrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
        }
        else
        {
            if (PhotonNetwork.IsConnectedAndReady)
                PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(22f, 1.8f, 32f), Quaternion.identity, 0);
            else
            {
                print("Inst");
                Instantiate(this.playerPrefabSingle, new Vector3(22f, 1.8f, 32f), Quaternion.identity);
            }
                
        }
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Menu");
    }

    public override void OnPlayerLeftRoom(Player other)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LeaveRoom();
        }

    }

    public void LeaveRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
            PhotonNetwork.LeaveRoom();
        else
        {
            SceneManager.LoadScene("Menu");
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonCoopLauncher : MonoBehaviourPunCallbacks
{
    bool isConnecting;
    RoomOptions roomOptions;

    [SerializeField] string roomName;
    [SerializeField] int maxPlayers;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        roomOptions = new RoomOptions();
        roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 2;
    }

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.CreateRoom("Room", roomOptions, TypedLobby.Default);
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            // keep track of the will to join a room, because when we come back from the game we will get a callback that we are connected, so we need to know what to do then
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            //PhotonNetwork.GameVersion = gameVersion;
        }
    }

    public void Joint()
    {
        PhotonNetwork.JoinRoom("Room");
    }

    public override void OnConnectedToMaster()
    {
        if (isConnecting && PhotonNetwork.IsMasterClient)
        {
            // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
            PhotonNetwork.CreateRoom("Room", roomOptions, TypedLobby.Default);
            isConnecting = false;
        }
        else if (isConnecting)
        {
            PhotonNetwork.JoinRoom("Room");
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}", cause);
        isConnecting = false;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room.");
    }

    public override void OnCreatedRoom()
    {
        PhotonNetwork.LoadLevel("GameRoom");
    }
}
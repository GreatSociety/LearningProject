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
        roomOptions.IsOpen = true;
        roomOptions.PublishUserId = true;

    }

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.CreateRoom("Room", roomOptions, TypedLobby.Default);
        }
        else
        {
            isConnecting = PhotonNetwork.ConnectUsingSettings();
        }
    }


    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            print("We here");

            // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
            PhotonNetwork.CreateRoom("Room", roomOptions, TypedLobby.Default);
            isConnecting = false;
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogWarningFormat("HEre" + message);
        PhotonNetwork.JoinRoom("Room");
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
        Debug.Log("OnCreatedRoom() called by PUN. Now this client is in a room.");
        //PhotonNetwork.LoadLevel("GameRoom");
    }

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom
            LoadArena();
        }
    }

    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel("GameRoom");
    }
}
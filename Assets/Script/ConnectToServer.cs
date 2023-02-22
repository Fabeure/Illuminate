using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            print("Connecting to server..");
            PhotonNetwork.ConnectUsingSettings();
        } 
    }

    
    public override void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){
        SceneManager.LoadScene(2);
    }

}

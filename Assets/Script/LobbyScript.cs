using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyScript : MonoBehaviourPunCallbacks
{
    public static LobbyScript instance;
    public void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public bool player1=false;
    public bool player2=false;
    public int test=1;

    

    public void createRoom(){
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        player1 = true;
        PhotonNetwork.CreateRoom(createInput.text, roomOptions, null);
    }
    public void joinRoom(){
        player2 = true;
        PhotonNetwork.JoinRoom(joinInput.text);
        Debug.Log(joinInput.text);
    }


    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("SampleScene");
    }
}

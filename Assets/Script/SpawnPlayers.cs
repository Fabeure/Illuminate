using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
  
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public void Start(){
        Vector2 pos = new Vector2(-9, 7);
        Vector2 pos2 = new Vector2(-100,-100);
        
        //if is player
        
        
        if (LobbyScript.instance.player1){
            Object.Instantiate(playerPrefab, pos, Quaternion.identity);
        }
        else{
            Object.Instantiate(playerPrefab, pos2, Quaternion.identity);
        }
        //if is watcher
    }
}

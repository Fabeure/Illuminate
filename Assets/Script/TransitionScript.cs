using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TransitionScript : MonoBehaviour
{

    public IEnumerator ChangeToScene(string sceneToChangeTo)
 {
     yield return new WaitForSeconds(1);
     Application.LoadLevel(sceneToChangeTo);
 }
    void Start(){
        PhotonNetwork.Disconnect();
        StartCoroutine(ChangeToScene("Menu"));
    }
}

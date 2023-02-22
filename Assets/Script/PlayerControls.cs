using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class PlayerControls : MonoBehaviour
{


    public bool done=false;
    PhotonView view;
    public Rigidbody2D rb;

    public GameObject key;
    public GameObject WinPortal;
    public GameObject LosePortal;
    public GameObject intedWinPortal;
    public GameObject intedLosePortal;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool onGround;

    public bool win;
    public Transform WinCheck;
    public float WinCheckRadius;
    public LayerMask whatIsWin;
    
    public bool hasKey;
    public bool obtainedKey;
    public Transform KeyCheck;
    public float KeyCheckRadius;
    public LayerMask whatIsKey;

    public Transform deadCheck;
    public float deadCheckRadius;
    public LayerMask whatIsDead;
    public bool dead;

    public GameObject Light;
    public Vector3 Lightpos;
    public Vector3 pos;

    public bool player2destruction=false;
    public GameObject intedKey;

    Vector2 poskey = new Vector2(-10.59f, 1.5f);
    Vector2 WinPortalPos = new Vector2(24.15f, 13.5f);
    Vector2 LosePortalPos = new Vector2(24.15f, 13.5f);
    Vector2 Textpos = new Vector2(-2, 4.5f);

   public IEnumerator ChangeToScene(string sceneToChangeTo)
 {
     yield return new WaitForSeconds(0.5f);
     Application.LoadLevel(sceneToChangeTo);
 }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if (LobbyScript.instance.player1){
        intedKey = (GameObject) PhotonNetwork.Instantiate(key.name, poskey, Quaternion.identity);
        intedLosePortal = (GameObject) PhotonNetwork.Instantiate(LosePortal.name, LosePortalPos, Quaternion.identity);
        }
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        pos = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z);
    }
    public Vector3 viewportPoint;
    public bool OffScreen=false;
    // Update is called once per frame
    void Update()
    {
        
        viewportPoint = Camera.main.WorldToViewportPoint(transform.position);
        OffScreen = (viewportPoint.x < 0 || viewportPoint.x > 1 || viewportPoint.y < 0 || viewportPoint.y > 1);
        if(OffScreen || dead)
        {
            pos.y += 0.5f;
            transform.position = pos;

        }
        
            
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        dead = Physics2D.OverlapCircle(deadCheck.position, deadCheckRadius, whatIsDead);
        win = Physics2D.OverlapCircle(WinCheck.position, WinCheckRadius, whatIsWin);
        hasKey = Physics2D.OverlapCircle(KeyCheck.position, KeyCheckRadius, whatIsKey);

        if (LobbyScript.instance.player1){
            //TESTING, REMOVE BEFORE COMMIT 
            /*
            if (Input.GetKey(KeyCode.RightArrow)){
                rb.velocity = new Vector2(4, rb.velocity.x);
            }
            if (Input.GetKey(KeyCode.LeftArrow)){
                rb.velocity = new Vector2(-4, rb.velocity.x);
            }
            if (Input.GetKey(KeyCode.UpArrow)){
                rb.velocity = new Vector2(4, rb.velocity.y);
            }
/////////////////////
                    if (Input.GetMouseButtonDown(0)){
                        rb.velocity = new Vector2(4, rb.velocity.x);
                        }
                    */

            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width/2 && touch.position.y  < Screen.height/2)
                {
                    rb.velocity = new Vector2(-4, rb.velocity.y);
                }
                else if (touch.position.x > Screen.width/2 && touch.position.y  < Screen.height/2)
                {
                    rb.velocity = new Vector2(4, rb.velocity.y);
                }
                else if (touch.position.x < Screen.width/2 && touch.position.y  > Screen.height/2 && onGround)
                {
                    rb.velocity = new Vector2(4, 8.5f);
                }
                else if (touch.position.x > Screen.width/2 && touch.position.y  > Screen.height/2 && onGround)
                {
                    rb.velocity = new Vector2(4, 8.5f);

                }
            }
            if (hasKey && !done){
                PhotonNetwork.Destroy(intedLosePortal);
                intedWinPortal = (GameObject) PhotonNetwork.Instantiate(WinPortal.name, WinPortalPos, Quaternion.identity);
                PhotonNetwork.Destroy(intedKey);
                obtainedKey = true;
                done = true;
                
            }
            if (win && obtainedKey){
                StartCoroutine(ChangeToScene("WinScene"));
            }
            else if (win && !obtainedKey){
                Debug.Log("get key first");
            }
        }
        else if(LobbyScript.instance.player2){
            if (Input.GetMouseButtonDown(0)){
                Vector3 mousepos = Input.mousePosition;
                Vector3 pos = Camera.main.ScreenToWorldPoint(mousepos);
                PhotonNetwork.Instantiate(Light.name, pos, Quaternion.identity);
            }
            if (win){
                StartCoroutine(ChangeToScene("WinScene"));
            }
        
    }
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public Transform PlayerCheck;
    public float PlayerCheckRadius;
    public LayerMask whatIsPlayer;
    public bool nearPlayer;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nearPlayer = Physics2D.OverlapCircle(PlayerCheck.position, PlayerCheckRadius, whatIsPlayer);
        if (nearPlayer){
            Debug.Log("player got key");
        }
    }
}

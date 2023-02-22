using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyLight : MonoBehaviour
{
    int lifeTime = 1;
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(WaitThenDie());
    }

    IEnumerator WaitThenDie()
 {
     yield return new WaitForSeconds(lifeTime);
     Destroy(gameObject);
 }
}

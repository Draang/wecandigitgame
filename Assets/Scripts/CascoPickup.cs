using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CascoPickup : MonoBehaviour
{
    int enterIntents=0;
   private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag=="Player" && enterIntents==0){
         enterIntents++;
        Destroy(gameObject);
        FindObjectOfType<GameSession>().setMoreLifes();
        Debug.Log("player pickup a life");
    }
   }
}

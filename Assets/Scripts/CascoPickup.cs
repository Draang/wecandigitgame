using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CascoPickup : MonoBehaviour
{
    bool liveCollected=false;
   private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag=="Player" && !liveCollected){
         liveCollected=true;
         gameObject.SetActive(false);
        Destroy(gameObject);
        FindObjectOfType<GameSession>().setMoreLifes();
    }
   }
}

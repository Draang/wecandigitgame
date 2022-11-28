using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHeads : MonoBehaviour
{
    
    
    void Start()
    {

    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="bullet"){
            Debug.Log("has been hit");
            Destroy(gameObject);
        }
    }
}

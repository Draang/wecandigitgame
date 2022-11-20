using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CascoLost : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    GameSession gameSession;
    Vector2 deathKick = new Vector2(-10f, -10f);
    // Start is called before the first frame update
    void Start()
    {
                myRigidbody = GetComponent<Rigidbody2D>();
 
        gameSession = FindObjectOfType<GameSession>();
        myRigidbody.velocity=deathKick;
    }
        private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] GameObject[] enemySpawners;
    [SerializeField] GameObject[] heads;
float moveSpeed = 4.5f;
  float moveRate = 4.5f;
    GameSession gameSession;
    Rigidbody2D myRigidBody;
    bool flagIsMoving=true;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameSession.GetGameRunning())
        {
            return;
        }
        if(flagIsMoving){
        moveRate = transform.localScale.x > 0 ? moveSpeed : -moveSpeed;
        myRigidBody.velocity = new Vector2(moveRate, 0f);}
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            return;
        }
        Flip();
    }
     void Flip()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
    //Create secuencia para la activacion de targets
    
}

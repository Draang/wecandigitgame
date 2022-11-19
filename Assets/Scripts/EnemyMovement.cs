using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;

    [SerializeField]
    float moveSpeed = 1f;
    GameSession gameSession;
  

    //create a ia to move the enemy




    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
      
    }

    void Update()
    {
        if (gameSession.GetGameRunning())
        {
            if (IsFacingRight())
            {
                myRigidBody.velocity = new Vector2(moveSpeed, 0f);
            }
            else
            {
                myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
            }
        }
    }

    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
}

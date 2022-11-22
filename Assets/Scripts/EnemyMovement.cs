using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;

    [SerializeField]
    float moveSpeed = 1f;
    float moveRate = 1f;
    GameSession gameSession;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        if (!gameSession.GetGameRunning())
        {
            return;
        }
        moveRate = transform.localScale.x > 0 ? moveSpeed : -moveSpeed;
        myRigidBody.velocity = new Vector2(moveRate, 0f);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            return;
        }
        Flip();
    }
    //avoid enemy to collide with another if it is so close
    void OnTriggerStay2D(Collider2D collision)
    {
        //check if other enemy is close
        if (collision.gameObject.tag == "Enemy")
        {
            //check if other enemy is on the right
            Invoke("Flip", 0.6f);
        }
    }
    void Flip()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
}


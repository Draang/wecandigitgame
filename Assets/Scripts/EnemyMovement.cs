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
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
}

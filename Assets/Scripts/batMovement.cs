using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batMovement : MonoBehaviour
{
    // Rigidbody2D myRigidBody;

    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private Vector3[] positions;
    private int index;
    private Transform target;
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        // if(Vector2)
        if(Vector2.Distance(transform.position, target.position) > 3){
            transform.position  = Vector2.MoveTowards (transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        transform.position = Vector2.MoveTowards(transform.position, positions[index], moveSpeed * Time.deltaTime);
        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }
    // GameSession gameSession;

    // void Start()
    // {
    //     myRigidBody = GetComponent<Rigidbody2D>();
    //     gameSession = FindObjectOfType<GameSession>();
    // }

    // void Update()
    // {
    //     if (gameSession.GetGameRunning())
    //     {
    //         if (IsFacingRight())
    //         {
    //             myRigidBody.velocity = new Vector2(moveSpeed, 0f);
    //         }
    //         else
    //         {
    //             myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
    //         }
    //     }
    // }

    // bool IsFacingRight()
    // {
    //     return transform.localScale.x > 0;
    // }

    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    // }
}

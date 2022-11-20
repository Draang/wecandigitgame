using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;

    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private Vector3[] positions;
    private int index;
    private Transform target;
    [SerializeField]
    private float attackDistance;
    GameSession gameSession;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (!gameSession.GetGameRunning())
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < attackDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.localScale = new Vector2(IsPlayerAtRight(transform.position.x, target.transform.position.x) ? (-Mathf.Sign(myRigidBody.velocity.x)) : (Mathf.Sign(myRigidBody.velocity.x)), 1f);
        }
        else
        {
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

        bool IsPlayerAtRight(float player, float enemy)
        {
            return player > enemy;
        }
    }
}

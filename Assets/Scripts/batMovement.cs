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
    [SerializeField]
    private float attackDistance;

    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        // if(Vector2)
        if(Vector2.Distance(transform.position, target.position) < attackDistance){
            transform.position  = Vector2.MoveTowards (transform.position, target.position, moveSpeed * Time.deltaTime);
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
    }
}

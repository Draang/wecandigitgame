using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float moveSpeed = 1f;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();


    }
    void Update()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, 0);

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed *= -1;
        FlipEnemyFacin();
    }

    void FlipEnemyFacin()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

}

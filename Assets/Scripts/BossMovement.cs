using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] GameObject[] enemySpawners;

    float moveSpeed = 4.5f;
    // float moveRate = 4.5f;
    GameSession gameSession;
    Rigidbody2D myRigidBody;
    bool flagIsMoving = true;
    [SerializeField] GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
        exit = GameObject.Find("Exit");
        exit.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        if (!gameSession.GetGameRunning())
        {
            return;
        }
        if (flagIsMoving)
        {
            //move left to right
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y), moveSpeed * Time.deltaTime);
            if (transform.position.x == 0)
            {
                flagIsMoving = false;
            }
        }
        else
        {
            //move right to left
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-10, transform.position.y), moveSpeed * Time.deltaTime);
            if (transform.position.x == -10)
            {
                flagIsMoving = true;
            }
        }
        //     transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 5, transform.position.y), moveSpeed * Time.deltaTime);
        //     if (transform.position.x <= -5)
        //     {
        //         flagIsMoving = false;
        //     }

        //     // moveRate = transform.localScale.x > 0 ? moveSpeed : -moveSpeed;
        //     // myRigidBody.velocity = new Vector2(moveRate, 0f);
        // }
        // {
        // }
    }
    //create stop moving coroutine

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "bullet")
        {

            Flip();
        }
    }

    void Flip()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
    public void setActiveExit()
    {
        exit.SetActive(true);
    }
    //Create secuencia para la activacion de targets

}

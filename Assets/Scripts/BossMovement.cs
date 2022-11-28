using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] GameObject[] enemySpawners;

    float moveSpeed = 4.5f;
    float moveRate = 4.5f;
    GameSession gameSession;
    Rigidbody2D myRigidBody;
    bool flagIsMoving = true;
    [SerializeField] GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
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
            //move side by side
            moveRate = transform.localScale.x > 0 ? moveSpeed : -moveSpeed;
            myRigidBody.velocity = new Vector2(moveRate, 0f);
        }
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
    public void setActiveExit(){
        exit.SetActive(true);
    }
    //Create secuencia para la activacion de targets

}

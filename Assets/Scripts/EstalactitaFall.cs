using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstalactitaFall : MonoBehaviour
{
    Rigidbody2D myRigdBody;
    [SerializeField] float moveSpeed = 5f;
    GameSession gameSession;
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myRigdBody = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
       myAnimator = GetComponent<Animator>();
    }


    public void changeGravity()
    {
        myRigdBody.gravityScale = moveSpeed;
        myAnimator.SetTrigger("isFalling");

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "platforms")
        {
         Destroy(gameObject,0.3f);
        }
    }

}

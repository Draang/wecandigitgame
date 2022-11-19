using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstalactitaFall : MonoBehaviour
{
    Rigidbody2D myRigdBody;
    [SerializeField] float moveSpeed = 5f;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        myRigdBody = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
    }


    public void changeGravity()
    {
        myRigdBody.gravityScale = moveSpeed;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "platforms")
        {
            Invoke("destroyOnTouchingPlataform", 0.3f);
        }
    }
    private void destroyOnTouchingPlataform()
    {
        Destroy(gameObject);
    }

}
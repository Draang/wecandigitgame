using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] AnimatorControllerParameter enemyAnimation;
    PlayerMovement player;
    GameSession gameSession;
    float xSpeed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        gameSession = FindObjectOfType<GameSession>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        if (gameSession.GetGameRunning())
        {
            myRigidbody.velocity = new Vector2(xSpeed, 0f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemys")
        {
            other.GetComponent<Animator>().SetTrigger("Dying");
             Destroy(other.gameObject,0.35f);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}

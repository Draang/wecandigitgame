using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float ranSpeed = 8f;

    [SerializeField]
    float jumpSpeed = 15f;

    [SerializeField]
    float climbSpeed = 7f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScale;
    bool isAlive = true;

    [SerializeField]
    Vector2 deathKick = new Vector2(10f, 10f);

    [SerializeField]
    GameObject bullet;
    GameSession gameSession;

    [SerializeField]
    Transform gun;
    bool flagClimb = false;
    bool flagFall = false;
    bool allowShootingVar = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gameSession = FindObjectOfType<GameSession>();
        gravityScale = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
            return;
        if (!gameSession.GetGameRunning())
        {
            return;
        }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive)
            return;
        if (gameSession.GetGameRunning())
        {
            moveInput = value.Get<Vector2>();
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * ranSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHasSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasSpeed);
    }

    void FlipSprite()
    {
        bool playerHasSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasSpeed)
        {
            myAnimator.SetBool("isRunning", true);
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    void OnJump(InputValue value)
    {
        if (gameSession.GetGameRunning())
        {
            if (!isAlive)
                return;
            if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
                return;
            if (value.isPressed)
            {
                myRigidbody.velocity += new Vector2(0f, jumpSpeed);
            }
        }
    }

    void OnFire(InputValue value)
    {
        if (gameSession.GetGameRunning())
        {
            if (!isAlive)
                return;
            if (allowShootingVar)
            {
                Instantiate(bullet, gun.position, transform.rotation);
                myAnimator.SetBool("isShooting", true);
                allowShootingVar = false;
                Invoke("StopAnimationThrowing", 0.1f);
                Invoke("AllowShooting", 0.7f);
            }
        }
    }

    void AllowShooting()
    {
        // myAnimator.SetBool("isShooting", false);
        allowShootingVar = true;
    }

    void StopAnimationThrowing()
    {
        myAnimator.SetBool("isShooting", false);
    }

    void ClimbLadder()
    {
        if (gameSession.GetGameRunning())
        {
            if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
            {
                flagClimb = false;
                myRigidbody.gravityScale = gravityScale;
                myAnimator.SetBool("isClimbing", false);
                return;
            }
            if (moveInput.y == 1)
            {
                flagClimb = true;
            }
            if (flagClimb)
            {
                Vector2 playerVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
                myRigidbody.gravityScale = 0;
                myRigidbody.velocity = playerVelocity;
                bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
                myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
            }
        }
    }

    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemys", "Hazards", "Estalactita")))
        {
            Death();
        }
    }

    void Death()
    {
        isAlive = false;
        myAnimator.SetTrigger("Dying");
        myRigidbody.velocity = deathKick;
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
        /* Invoke("Restart", 1f); */
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (flagFall)
        {
            return;
        }
        if (other.gameObject.tag == "fallDetector")
        {
            flagFall = true;
            Death();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleBehavior : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    private Transform target;
    GameSession gameSession;
    [SerializeField]
    const int attckD = 8;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameSession = FindObjectOfType<GameSession>();
    }
    void Update()
    {
        if (!gameSession.GetGameRunning())
        {
            return;
        }
        SetAnimatorStatesFalse();
        switch (Vector2.Distance(transform.position, target.position))
        {
            case < attckD and > attckD - 2:
                myAnimator.SetBool("isLeaningOut1", true);
                break;
            case < attckD - 4 and > attckD - 6:
                myAnimator.SetBool("isLeaningOut2", true);
                break;
            case < attckD - 6 and > attckD - 8:
                myAnimator.SetBool("isLeaningOut3", true);
                break;
            case < attckD - 8:
                myAnimator.SetBool("isAttacking", true);
                break;
            default:
                SetAnimatorStatesFalse();
                break;
        }
    }
    void SetAnimatorStatesFalse()
    {
        myAnimator.SetBool("isLeaningOut1", false);
        myAnimator.SetBool("isLeaningOut2", false);
        myAnimator.SetBool("isLeaningOut3", false);
        myAnimator.SetBool("isAttacking", false);
    }
}

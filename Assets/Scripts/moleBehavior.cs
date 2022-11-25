using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleBehavior : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    private Transform target;

    [SerializeField]
    float moveRate = 0.5f;
    GameSession gameSession;

    [SerializeField] const float attckD = 12;
    Vector3 startPosition;
    Vector3 jumpPosition;
    Vector3[] jumps;
    private int index;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        jumps = new Vector3[] { transform.position, new Vector3(startPosition.x, startPosition.y + 3, 0) };
        myAnimator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void FixedUpdate()
    {
        if (!gameSession.GetGameRunning())
        {
            return;
        }
        Debug.Log(Mathf.Round(Vector2.Distance(new Vector2(transform.position.x, 0f), new Vector2(target.position.x, 0f))));
        switch (Mathf.Round(Vector2.Distance(new Vector2(transform.position.x, 0f), new Vector2(target.position.x, 0f))))
        {
            case <= attckD - 8:

                SetAnimatorStatesFalse(new string[] { "isLeaningOut1", "isLeaningOut2", "isLeaningOut3" });
                myAnimator.SetBool("isAttacking", true);
                jumpMole();
                break;
            case <= attckD - 6:
                Stop();
                SetAnimatorStatesFalse(new string[] { "isLeaningOut1", "isLeaningOut2", "isAttacking" });
                myAnimator.SetBool("isLeaningOut3", true);
                break;
            case <= attckD - 2:
                SetAnimatorStatesFalse(new string[] { "isLeaningOut2", "isLeaningOut3", "isAttacking" });
                Stop();
                myAnimator.SetBool("isLeaningOut1", true);

                break;
            default:
                Stop();
                SetAnimatorStatesFalse(new string[] { "isLeaningOut1", "isLeaningOut2", "isLeaningOut3", "isAttacking" });
                break;
        }

    }
    void SetAnimatorStatesFalse(string[] states)
    {
        foreach (string state in states)
        {
            myAnimator.SetBool(state, false);
        }
    }
    void jumpMole()
    {
        transform.position = Vector2.MoveTowards(transform.position, jumps[index], moveRate * Time.deltaTime);
        if (transform.position == jumps[index])
        {
            index = (index == jumps.Length - 1) ? 0 : ++index;
        }
    }
    void Stop()
    {
        transform.position = startPosition;
    }
}

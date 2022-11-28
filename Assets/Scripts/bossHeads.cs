using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHeads : MonoBehaviour
{
    GameObject Boss;
    Animator BossAnimator;

    void Start()
    {
        Boss = GameObject.Find("ReyLombriz");
        BossAnimator = Boss.GetComponent<Animator>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            Debug.Log("hited to   " + tag);

            BossAnimator.SetBool(tag, true);
            bool alive = BossAnimator.GetBool("head1") || BossAnimator.GetBool("head2") || BossAnimator.GetBool("head3");
            if (!alive)
            {
                Debug.Log("Boss death " + tag);
                BossAnimator.SetBool("Dying", alive);
                Destroy(Boss, 0.35f);
            }

            Destroy(gameObject);
        }
    }
}

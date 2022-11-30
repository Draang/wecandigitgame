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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {

            BossAnimator.SetBool(tag, true);
            bool alive = !BossAnimator.GetBool("head1") || !BossAnimator.GetBool("head2") || !BossAnimator.GetBool("head3");
            if (!alive)
            {
                BossAnimator.SetBool("Dying", alive);
                Boss.GetComponent<BossMovement>().setActiveExit();
                Destroy(Boss, 0.80f);
            }

            Destroy(gameObject);
        }
    }
}

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

            BossAnimator.SetBool(tag, true);

            Debug.Log(BossAnimator.GetBool("head1") + " " + BossAnimator.GetBool("head2") + " " + BossAnimator.GetBool("head3"));
            bool alive = !BossAnimator.GetBool("head1") || !BossAnimator.GetBool("head2") || !BossAnimator.GetBool("head3");
            bool alive2 = !BossAnimator.GetBool("head1") || !BossAnimator.GetBool("head2") || !BossAnimator.GetBool("head3");
            Debug.Log(alive + " " + alive2);
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

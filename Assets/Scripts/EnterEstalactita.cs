using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEstalactita : MonoBehaviour
{
    Animator myAnimator;
    EstalactitaFall estalactita;
    private void Start()
    {
        estalactita = FindObjectOfType<EstalactitaFall>();
        myAnimator=GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        myAnimator.SetTrigger("isSwitch");
        if (other.tag == "Player")
        {
            estalactita.changeGravity();
            Destroy(gameObject,0.4f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEstalactita : MonoBehaviour
{
    EstalactitaFall estalactita;
    private void Start()
    {
        estalactita = FindObjectOfType<EstalactitaFall>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            estalactita.changeGravity();
            Destroy(gameObject);
        }
    }
}

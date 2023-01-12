using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDeathController : MonoBehaviour
{

    playerHealth pH;
    Rigidbody2D rb;

    private void Start()
    {
        pH = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.simulated = false;
            pH.addDamage(4);
        }
    }

}

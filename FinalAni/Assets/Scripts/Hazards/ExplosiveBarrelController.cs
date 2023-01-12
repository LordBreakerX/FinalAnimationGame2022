using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelController : MonoBehaviour
{

    public float damage;
    public float pushBackForce;

    public GameObject explosionPS;
    Transform spawnPoint;
    public GameObject explosiveBarrel;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("EXBarrel").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Howdy!");
        if (collision.tag == "Player")
        {
            playerHealth pH = collision.gameObject.GetComponent<playerHealth>();
            pH.addDamage(damage);
            Instantiate(explosionPS, spawnPoint.transform.position, Quaternion.identity);
            Destroy(explosiveBarrel.gameObject);

        }
    }

    void pushBack(Transform pushedObject) 
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }

}

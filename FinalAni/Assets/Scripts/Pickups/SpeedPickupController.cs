using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickupController : MonoBehaviour
{
	public AudioClip rewardSound;
	public GameObject parent;
	public playerHealth pH;

    //public GameObject rewardObject;

    private void Start()
    {
		pH = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (!pH.speedActive)
            {
				//Instantiate(rewardObject, transform.position, Quaternion.identity);
				other.gameObject.GetComponent<playerControllerScript>().increaseSpeedFixed();
				AudioSource.PlayClipAtPoint(rewardSound, transform.position);
				pH.speedActive = true;
				Destroy(parent);
				
			} else
            {
				pH.currentTime = pH.maxSpeedTime;
				pH.speedBoostIndicator.fillAmount = 1;
				Destroy(parent);
			}
		}
	}
}

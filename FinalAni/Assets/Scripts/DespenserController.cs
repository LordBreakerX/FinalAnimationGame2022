using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespenserController : MonoBehaviour
{
    playerHealth pH;

    public int emeraldsNeeded;
    public GameObject prompt;

    public bool isHealthKit = false;

    int stockAmount;
    int soldStock = 0;

    private SpriteRenderer sR;
    public Sprite noStockSprite;

    bool playerInRange = false;

    public AudioSource AS;
    public AudioClip speedyAudio;
    public AudioClip healAudio;

    playerControllerScript pcs;

    public GameObject HeartsPS;
    public GameObject SP;

    private void Start()
    {
        pH = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        pcs = GameObject.FindGameObjectWithTag("Player").GetComponent<playerControllerScript>();
        sR = gameObject.GetComponent<SpriteRenderer>();
        stockAmount = Random.Range(1, 3);
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (isHealthKit)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print(pH.collectedRubies);
                    if (pH.collectedRubies >= emeraldsNeeded && soldStock < stockAmount)
                    {
                        soldStock++;
                        pH.MinusRuby(emeraldsNeeded);
                        pH.addHealth();
                        Instantiate(HeartsPS, SP.transform.position, Quaternion.identity);
                        AS.clip = healAudio;
                        AS.PlayOneShot(healAudio);
                    }
                }

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (pH.collectedRubies >= emeraldsNeeded && soldStock < stockAmount)
                    {
                        soldStock++;
                        pH.MinusRuby(emeraldsNeeded);
                        AS.clip = speedyAudio;
                        AS.PlayOneShot(speedyAudio);

                        if (!pH.speedActive)
                        {
                            pcs.increaseSpeedFixed();
                            pH.speedActive = true;
                        } else
                        {
                            pH.currentTime = pH.maxSpeedTime;
                            pH.speedBoostIndicator.fillAmount = 1;
                        }
                    }
                }
            }

            if (soldStock >= stockAmount)
            {
                sR.sprite = noStockSprite;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(false);
            playerInRange = false;
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeartManager : MonoBehaviour
{


    [Header("Properties")]
    public int heartIndex;
    public Sprite brokenHeart;
    public Sprite fullHeart;

    playerHealth pH;
    Animator myAnim;

    bool isComplete;

    Image heartImage;


    private void Start()
    {
        pH = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        myAnim = gameObject.GetComponent<Animator>();

        heartImage = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (!isComplete)
        {
            int temp = heartIndex;

            if (pH.currentHealth <= pH.fullHealth - temp && heartIndex == temp)
            {
                heartImage.sprite = brokenHeart;
                myAnim.SetBool("heartIsBroken", true);
                myAnim.SetBool("heartIsBack", false);
                isComplete = true;
            }
        }

        if (pH.currentHealth >= pH.fullHealth)
        {
            heartImage.sprite = fullHeart;
            myAnim.SetBool("heartIsBack", true);
            myAnim.SetBool("heartIsBroken", false);
            isComplete = false;
        }
    }

}

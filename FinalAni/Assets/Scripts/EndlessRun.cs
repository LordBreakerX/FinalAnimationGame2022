using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessRun : MonoBehaviour
{

    public ChangeLevel CL;
    public playerHealth pH;

    public static bool changeReady;

    public static int levelNum = 0;
    public static float health = 4;
    public static int emrolds = 0;
    public TMP_Text text;

    public static bool isDead;

    private void Start()
    {
        health = pH.fullHealth;

        isDead = pH.isDead;

        if (isDead)
        {
            pH.currentHealth = health;
            pH.collectedRubies = emrolds;
            levelNum++;
            changeReady = false;
            CL.changeReady = false;
            pH.isDead = false;
        } else
        {
            pH.currentHealth = pH.fullHealth;
            health = pH.currentHealth;
            levelNum++;
            emrolds = pH.collectedRubies;
            pH.isDead = false; 
        }        
    }

    private void Update()
    {
        
        CL = GameObject.FindGameObjectWithTag("EndlessRun").GetComponent<ChangeLevel>();
        text.text = "Endless Mode: Level " + levelNum.ToString();

        changeReady = CL.changeReady;
        if (!changeReady)
        {
            emrolds = pH.collectedRubies;
            health = pH.currentHealth;

        }

    }

}

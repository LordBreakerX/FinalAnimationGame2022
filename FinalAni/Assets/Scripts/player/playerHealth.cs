using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public float fullHealth;

    [HideInInspector]
    public float currentHealth;

    //Audio Feedback
    	public AudioClip playerDamaged;
        public AudioClip playerDeath;
    	AudioSource playerAS;

    //HUD references
    	//public Image healthSlider;
        public Image damageIndicator;
        
      //  public CanvasGroup endGameCanvas;
     //   public Text EndGameText;

        Color flashColour = new Color (255f, 255f, 255f, 0.5f);
        float indicatorSpeed = 5f;
    
    public Text rubyCount;

    //Player death
    playerControllerScript controlMovement;
    public bool isDead;
    bool damaged;
    //	public GameObject playerDeathFX;


    //ruby collection
    [HideInInspector]
    public int collectedRubies = 0;

    SpeedPickupController sPC;
    [HideInInspector]
    public bool speedActive;

    public float maxSpeedTime;
    [HideInInspector]
     public float currentTime;

    public Image speedBoostIndicator;

    // Use this for initialization
    void Start()
    {
        currentHealth = fullHealth;
        //		healthSlider.fillAmount = 0f;
        controlMovement = GetComponent<playerControllerScript>();
        playerAS = GetComponent<AudioSource> ();
        //		rubyCount.text = collectedRubies.ToString();
        currentTime = maxSpeedTime;

    }

    // Update is called once per frame
    void Update()
    {
        //are we damaged?
        		if (damaged) {
                    damageIndicator.color = flashColour;
                } else {
                    damageIndicator.color = Color.Lerp(damageIndicator.color, Color.clear, indicatorSpeed*Time.deltaTime);
                }
                damaged = false;

                if (speedActive)
                {
                 speedBoostIndicator.fillAmount = 1;
                    if (currentTime <= 0)
                    {
                speedBoostIndicator.fillAmount = 0;
                controlMovement.maxSpeed -= 4;
                speedActive = false;
                currentTime = maxSpeedTime;

                    } else
                    {
                    currentTime -= Time.deltaTime;
                speedBoostIndicator.fillAmount = (float)currentTime / maxSpeedTime;

                    
                    }
                }

    }

    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;
        //		healthSlider.fillAmount = 1 - currentHealth/fullHealth;
        		playerAS.clip = playerDamaged;
        		playerAS.PlayOneShot (playerDamaged);

        damaged = true;
        if (currentHealth <= 0)
        {
            makeDead();
        }

    }

    public void addHealth()
    {

        currentHealth = fullHealth;

        /*currentHealth += health;
        if (currentHealth > fullHealth)
            currentHealth = fullHealth;
               healthSlider.fillAmount = 1 - currentHealth / fullHealth;

        print("Got some health!"); */
    }

    public void makeDead()
    {
        playerAS.clip = playerDeath;
        playerAS.PlayOneShot(playerDeath);
        //kill the player - death particles - destroy character - sound
        isDead = true;
        //		Instantiate (playerDeathFX, transform.position, transform.rotation);
        		damageIndicator.color = flashColour;
        //		EndGameText.text = "You Died!";
        //		winGame();
        Destroy(gameObject);
    }

    public void addRuby()
    {
        collectedRubies += 1;
        rubyCount.text = collectedRubies.ToString();
        rubyCount.gameObject.GetComponent<Animator>().SetTrigger("addPoint");

        if (collectedRubies > 2)
        {
//            EndGameText.text = "You Win!";
//            GetComponent<playerControllerScript>().toggleCanMoveFalse();
            //           winGame();
        }
    }

    public void MinusRuby(int amount)
    {
        collectedRubies -= amount;
        rubyCount.text = collectedRubies.ToString();
        rubyCount.gameObject.GetComponent<Animator>().SetTrigger("addPoint");

        if (collectedRubies > 2)
        {
            //            EndGameText.text = "You Win!";
            //            GetComponent<playerControllerScript>().toggleCanMoveFalse();
            //           winGame();
        }
    }

    public void winGame()
    {
//        endGameCanvas.alpha = 1f;
//        endGameCanvas.interactable = true;
    }
}

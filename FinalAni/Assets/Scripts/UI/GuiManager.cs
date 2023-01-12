using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GuiManager : MonoBehaviour
{

    public playerHealth pH;

    public GameObject generalGUI;
    public GameObject GameOverMenu;

    public GameObject pauseMenu;

    bool isPaused;

    bool inOptions;

    public GameObject Playpoint;

    public AudioSource aS;


    private void Update()
    {
        if (pH.currentHealth <= 0)
        {
            GameOver(GameOverMenu, generalGUI);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pH.currentHealth > 0 && !inOptions)
            {

                if (isPaused)
                {
                    PanelDisable(pauseMenu);
                    isPaused = false;
                    Time.timeScale = 1;
                }
                else
                {
                    PanelEnable(pauseMenu);
                    isPaused = true;
                    Time.timeScale = 0;
                }
            }
        }
    }

    public void PlayClick()
    {
        aS.Play();
    }

    public void OpenedOptions()
    {
        inOptions = true;
    }

    public void ClosedOptions()
    {
        inOptions = false;
    }

    public void ResumeGame()
    {
        PanelDisable(pauseMenu);
        isPaused = false;
        Time.timeScale = 1;
    }

    public void PanelDisable(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void PanelEnable(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
        pH.currentHealth = pH.fullHealth;
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        pH.currentHealth = pH.fullHealth;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void InteractiveDisable(Button toAffect)
    {
        toAffect.interactable = false;
    }

    public void InteractiveEnable(Button toAffect)
    {
        toAffect.interactable = true;
    }

    public void GameOver(GameObject panelActive, GameObject panelDeactive)
    {
        PanelEnable(panelActive);
        PanelDisable(panelDeactive);
    }

}

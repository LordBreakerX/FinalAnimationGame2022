using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class OptionsUIManager : MonoBehaviour
{

    public AudioMixer mixerMaster;

    float masterVol;
    float bGMVol;
    float sFXVol;

    public TextMeshProUGUI masterText;
    public TextMeshProUGUI sfxText;
    public TextMeshProUGUI bgmText;

    bool sfxIsMuted;
    bool bgmIsMuted;

    public Slider sliderBGM;
    public Slider sliderSFX;

    float lastBGMV;
    float lastSFXV;

    public void SetSFX(bool playSFX)
    {
        if (!playSFX)
        {
            sfxIsMuted = true;
            mixerMaster.SetFloat("sFXVol", -80);
            sliderSFX.value = -80;
            sfxText.text = "0% (MUTED)";
        } else
        {
            sfxIsMuted = false;
            sliderSFX.value = lastSFXV;
            mixerMaster.SetFloat("sFXVol", lastSFXV);
            sfxText.text = Mathf.Round((lastSFXV + 80) / 80 * 100).ToString() + "%";
        }
    }

    public void SetBGM(bool playBGM)
    {
        if (!playBGM)
        {
            bgmIsMuted = true;
            mixerMaster.SetFloat("bGMVol", -80);
            sliderBGM.value = -80;
            bgmText.text = "0% (MUTED)";
        } else
        {
            bgmIsMuted = false;
            sliderBGM.value = lastBGMV;
            mixerMaster.SetFloat("bGMVol", lastBGMV);
            bgmText.text = Mathf.Round((lastBGMV + 80) / 80 * 100).ToString() + "%";
        }
    }

    public void SetMV(float MV)
    {
       mixerMaster.SetFloat("masterVol", MV);
        masterVol = Mathf.Round((MV + 80)/80 * 100);
        masterText.text = masterVol.ToString() + "%";
    }

    public void SetSFXV(float SFXV)
    {
        if (!sfxIsMuted)
        {
            lastSFXV = SFXV;
            mixerMaster.SetFloat("sFXVol", SFXV);
            sFXVol = Mathf.Round((SFXV + 80) / 80 * 100);
            sfxText.text = sFXVol.ToString() + "%";
        } else
        {
            sliderSFX.value = -80;
        }
    }

    public void SetBGMV(float BGMV)
    {
        if (!bgmIsMuted)
        {
            lastBGMV = BGMV;
            mixerMaster.SetFloat("bGMVol", BGMV);
            bGMVol = Mathf.Round((BGMV + 80) / 80 * 100);
            bgmText.text = bGMVol.ToString() + "%";
        } else
        {
            sliderBGM.value = -80;
        }
    }

}

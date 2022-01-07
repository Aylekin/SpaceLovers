using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    public Slider musicSlider;
    public Slider effectsSlider;
    public Toggle TogMusic;
    public Toggle TogEffects;

    public void MusicToggle(bool newValue)
    {
        musicSlider.value = -60;
        musicSlider.interactable = newValue;
    }

    public void EffectsToggle(bool newValue)
    {
        effectsSlider.value = -60;
        effectsSlider.interactable = newValue;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("select"))
        {
            if (PlayerPrefs.GetInt("select") == 1)
            {
                TogMusic.isOn = true;
            }
            else
            {
                TogMusic.isOn = false;
            }
        }

        if (PlayerPrefs.HasKey("select1"))
        {
            if (PlayerPrefs.GetInt("select1") == 1)
            {
                TogEffects.isOn = true;
            }
            else
            {
                TogEffects.isOn = false;
            }
        }
    }

    private void Update()
    {
        if (TogMusic.isOn == true)
        {
            PlayerPrefs.SetInt("select", 1);
        }
        else
        {
            PlayerPrefs.SetInt("select", 0);
        }

        if (TogEffects.isOn == true)
        {
            PlayerPrefs.SetInt("select1", 1);
        }
        else
        {
            PlayerPrefs.SetInt("select1", 0);
        }
    }
}

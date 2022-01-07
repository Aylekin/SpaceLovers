using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    public AudioMixer audioMixer;
    [Space(10)]
    public Slider musicSlider;
    public Slider effectsSlider;

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("effectsVolume", volume);
    }
    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume",10);
        effectsSlider.value = PlayerPrefs.GetFloat("effectsVolume");
    }
    private void OnDisable()
    {
        float musicVolume = 0;
        float effectsVolume = 0;
        audioMixer.GetFloat("musicVolume", out musicVolume);
        audioMixer.GetFloat("effectsVolume", out effectsVolume);

        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("effectsVolume", effectsVolume);
        PlayerPrefs.Save();
    }
}

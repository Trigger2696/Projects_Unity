﻿using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectSlider;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectAudio;
    private float backgroundFloat, soundEffectFloat;
   



  

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backgroundFloat = .25f;
            soundEffectFloat = .75f;
            backgroundSlider.value = backgroundFloat;
            soundEffectSlider.value = soundEffectFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            soundEffectSlider.value = soundEffectFloat;
        }
    }

    public void SaveSoundSettings()
    {
        //PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        //PlayerPrefs.SetFloat(SoundEffectPref, soundEffectSlider.value);
    }
  
    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
         
        for (int i=0; i < soundEffectAudio.Length; i++)
        {
            soundEffectAudio[i].volume = soundEffectSlider.value;

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerScript : MonoBehaviour
{
    public Slider masterSlider, musicSlider, sfxSlider, uiSlider;
    public AudioMixer mixer;


    void Start()
    {
        MixerVolume();

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            uiSlider.value = PlayerPrefs.GetFloat("UIVolume");
        }

        else
        {
            SetSliders();
        }
    }

    private void SetSliders()
    {
        masterSlider.value = .5f;
        musicSlider.value = .5f;
        sfxSlider.value = .5f;
        uiSlider.value = .5f;
    }

    public void MixerVolume()
    {
        mixer.SetFloat("UiVolume", 1);
        mixer.SetFloat("MusicVolume", 1);
        mixer.SetFloat("SFXVolume", 1);
        mixer.SetFloat("MasterVolume", 1);
    }

    public void MusicVolumeValue(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public void MasterVolumeValue(float volume)
    {
        mixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    public void SFXVolumeValue(float volume) 
    {
        mixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }

    public void UiVolumeValue(float volume)
    {
        mixer.SetFloat("UiVolume", volume);
        PlayerPrefs.SetFloat("UIVolume", uiSlider.value);
    }


}

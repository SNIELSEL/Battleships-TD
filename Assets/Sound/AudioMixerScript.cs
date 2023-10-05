using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class AudioMixerScript : MonoBehaviour
{
    public Slider masterSlider, audioSlider, sfxSlider, uiSlider;
    public GameObject slider;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        MixerVolume();

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            //mixer.SetFloat("Musicvolume");
        }
    }

    // Update is called once per frame
    void Update()
    {

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
        PlayerPrefs.SetFloat("MusicVolume", masterSlider.value);
    }

    public void MasterVolumeValue(float volume)
    {
        mixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    public void SFXVolumeValue(float volume) 
    {
        mixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("SFXVolume", masterSlider.value);
    }

    public void UiVolumeValue(float volume)
    {
        mixer.SetFloat("UiVolume", volume);
        PlayerPrefs.SetFloat("UIVolume", masterSlider.value);
    }


}

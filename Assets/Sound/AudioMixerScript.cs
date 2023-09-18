using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class AudioMixerScript : MonoBehaviour
{
    public Slider audioSlider;
    public GameObject slider;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        MixerVolume();
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
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumeSlide : MonoBehaviour
{
    public Slider volumeSlider;

    public SaveAndLoad saveAndLoad;

    void Start()
    {
        LoadVolume();
        /*
        if (saveAndLoad.volume == 0)
        {
            saveAndLoad.volume = 1;
            SaveVolume();
            LoadVolume();
        }
        */
    }

    public void VolumeChanger()
    {
        //saveAndLoad.volume = volumeSlider.value;
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    public void LoadVolume()
    {
        //saveAndLoad.LoadData();
        //volumeSlider.value = saveAndLoad.volume;
    }

    public void SaveVolume()
    {
       // saveAndLoad.SaveData();
    }

}

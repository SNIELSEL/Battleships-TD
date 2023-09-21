using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ResolutionControll : MonoBehaviour
{
    public TMP_Dropdown resolutionDropDown;

    private Resolution[] resolutions;
    private List<Resolution> filterdResolutions;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;

    private int decimals = 0;

    private void Start()
    {
        resolutions = Screen.resolutions;
        filterdResolutions = new List<Resolution>();

        resolutionDropDown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for(int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filterdResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for(int i = 0; i < filterdResolutions.Count; i++)
        {
            string resolutionOptions = filterdResolutions[i].width+ "x"+ filterdResolutions[i].height+ " "+ filterdResolutions[i].refreshRate + "Hz";
            options.Add(resolutionOptions);

            if (filterdResolutions[i].width == Screen.width && filterdResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetResolution(int reslutionIndex)
    {
        Resolution resolution = filterdResolutions[reslutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);

        if(Screen.fullScreen == true)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }
}

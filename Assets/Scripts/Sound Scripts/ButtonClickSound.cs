using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSound;

    public void Start()
    {
        audioSource.clip = buttonSound;
    }

    public void OnButtonClick()
    {
        audioSource.Play();
    }
}

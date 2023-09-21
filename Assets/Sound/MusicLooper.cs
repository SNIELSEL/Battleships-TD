using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{
    public AudioSource musicPlayer;
    public AudioClip[] musicClips;

    public int currentMusic, lastMusic;
    public bool isPlaying;

    void Update()
    {
        if(musicPlayer.isPlaying == false)
        {
            isPlaying= false;

            currentMusic = Random.Range(0, musicClips.Length -1);
            musicPlayer.clip = musicClips[currentMusic];
            musicPlayer.Play();

            isPlaying = true;
            lastMusic = currentMusic;
        }

        if (lastMusic == currentMusic && !isPlaying)
        {
                lastMusic = currentMusic;
                currentMusic = Random.Range(0, musicClips.Length -1);
        }
    }
}

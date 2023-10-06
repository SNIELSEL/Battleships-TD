using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float seconds = 0;
    public int minutes = 15;

    public TextMeshProUGUI timerSecondsText;
    public TextMeshProUGUI timerMinutesText;

    public GameObject[] toEnable;
    public GameObject[] toDisable;

    private float secondsInt;

    public bool timeUp;

    public void Update()
    {
        secondsInt = (int)seconds;

        timerSecondsText.text = secondsInt.ToString();
        timerMinutesText.text = minutes.ToString();

        seconds -= Time.deltaTime;

        if(seconds <= 0)
        {
            minutes--;
            seconds = 60;
        }

        if(minutes <= 0)
        {
            for (int i = 0; i < toDisable.Length; i++)
            {
                toDisable[i].SetActive (false);
            }

            for (int i = 0; i < toEnable.Length; i++)
            {
                toEnable[i].SetActive (true);
            }
        }
    }
}

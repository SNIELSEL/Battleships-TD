using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class GameTimer : MonoBehaviour
{
    public float seconds = 0;
    public int minutes = 15;

    public TextMeshProUGUI timerSecondsText, shipmenuSecond;
    public TextMeshProUGUI timerMinutesText, shipMenuMinutes;

    public GameObject[] toEnable;
    public GameObject[] toEnableWin;

    public GameObject[] toDisable;

    private float secondsInt;

    public bool timeUp;

    private PlaneSender planeSender;

    public void Start()
    {
        planeSender = gameObject.GetComponent<PlaneSender>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            seconds = 5f;
            minutes = 0;
        }

        secondsInt = (int)seconds;

        if(secondsInt >= 10)
        {
            timerSecondsText.text = secondsInt.ToString();
            shipmenuSecond.text = secondsInt.ToString();
        }
        else
        {
            timerSecondsText.text = "0" + secondsInt.ToString();
            shipmenuSecond.text = "0" + secondsInt.ToString();
        }

        if(minutes >= 10)
        {
            timerMinutesText.text = minutes.ToString();
            shipMenuMinutes.text = minutes.ToString();
        }
        else
        {
            timerMinutesText.text = "0" + minutes.ToString();
            shipMenuMinutes.text = "0" + minutes.ToString();
        }

        seconds -= Time.deltaTime;

        if(seconds <= 0)
        {
            seconds = 60;
            minutes--;
        }

        if(minutes <= 0 && minutes <=0 - 1)
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

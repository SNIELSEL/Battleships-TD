using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float money;

    public int multiplier;

    public TextMeshProUGUI hUDMoneyText, shipMenuMoneyText;

    private int moneyDisplayed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            money = 99999;
        }

        money += Time.deltaTime * multiplier;

        moneyDisplayed = (int)money;

        hUDMoneyText.text = moneyDisplayed.ToString();
        shipMenuMoneyText.text = moneyDisplayed.ToString();
    }
}

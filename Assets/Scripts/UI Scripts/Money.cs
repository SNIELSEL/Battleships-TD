using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int money;

    public int multiplier;

    public TextMeshProUGUI moneyText;

    // Update is called once per frame
    void Update()
    {
        money += (int)Time.deltaTime * multiplier;

        moneyText.text = money.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eiland : ShipBaseScript
{
    public GameObject winsScreen;
    public GameObject[]  uitUI;

    public override void Update()
    {
        base.Update();

        if (shipSunk)
        {
            winsScreen.SetActive(true);

            for (int i = 0; i < uitUI.Length; i++)
            {
                uitUI[i].SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.F7))
        {
            shipSunk = true;
        }
    }
}

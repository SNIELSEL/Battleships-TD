using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : ShipBaseScript
{
    public bool isEnemy;

    public override void Start()
    {
        base.Start();

        if (isEnemy)
        {
            destroyedShipMoney = 500;
        }
    }
}

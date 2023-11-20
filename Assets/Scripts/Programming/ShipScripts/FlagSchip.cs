using Bitgem.VFX.StylisedWater;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagSchip : ShipBaseScript
{
    public bool flagShipSunk;

    public GameObject[] toEnable;
    public GameObject[] toDisable;

    public override void ShipDestroyed()
    {
        //sinking
        if (health <= 0)
        {
            GetComponent<Rigidbody>().useGravity = true;
            
            if (GetComponent<WateverVolumeFloater>() != null)
            {
                GetComponent<WateverVolumeFloater>().enabled = false;
            }

            shipSunk = true;
            flagShipSunk = true;
            StartCoroutine(ShipHasSunk());
        }
    }

    public override void Update()
    {

        if (Input.GetKeyDown(KeyCode.F10))
        {
            health = 10;
        }

        if (shipSunk)
        {
            SinkingShipRotation();
        }

        ShipDestroyed();
        NameSelection();
        DetectedPlayer();
    }

    public IEnumerator ShipHasSunk()
    {
        yield return new WaitForSeconds(10);

        if (flagShipSunk)
        {
            Debug.Log("hi");

            for (int i = 0; i < toDisable.Length; i++)
            {
                toDisable[i].SetActive(false);
            }

            for (int i = 0; i < toEnable.Length; i++)
            {
                toEnable[i].SetActive(true);
            }
        }
    }
}

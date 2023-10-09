using Bitgem.VFX.StylisedWater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagSchip : ShipBaseScript
{
    public bool flagShipSunk;

    public override void ShipDestroyed()
    {
        //sinking
        if (health <= 0)
        {
            this.GetComponent<WateverVolumeFloater>().enabled = false;

            flagShipSunk = true;
        }
    }
}

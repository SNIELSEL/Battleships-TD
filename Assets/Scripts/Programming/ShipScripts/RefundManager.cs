using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefundManager : MonoBehaviour
{
    public int respawnTime;

    public ShipBaseScript shipToBlowUp;

    public string[] shipIDs;
    public GameObject[] spawnButtons;
    public int[] spawnIndex;

    private int enableIndex;
    public void BlowUpShip()
    {
        StartCoroutine(shipToBlowUp.Explode());

        for (int i = 0; i < shipIDs.Length; i++)
        {
            if(shipToBlowUp.shipIdentifyer == shipIDs[i])
            {
                if(i == spawnIndex[i])
                {
                    enableIndex = i;
                    StartCoroutine(SpawnShip());
                }
            }
        }
    }

    public IEnumerator SpawnShip()
    {
        yield return new WaitForSeconds(respawnTime);
        spawnButtons[enableIndex].SetActive(true);
    }
}

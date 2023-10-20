using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSender : MonoBehaviour
{
    public Transform spawnlocation;

    public GameObject[] planePrefab;
    public int[] planeCost;
    public Transform parentObject;
    public int planeNumber;

    private Money moneyScrip;

    private int cheatWin;
    public bool cheatWon;
    public void Start()
    {
        moneyScrip = gameObject.GetComponent<Money>();
    }

    public void Update()
    {
        if(cheatWin == 10)
        {
            StartCoroutine(WinGame());
        }
    }

    public IEnumerator WinGame()
    {
        yield return new WaitForSeconds(15);

        cheatWon = true;
    }

    public void SpawnPlane()
    {
        if (moneyScrip.money >= planeCost[planeNumber])
        {
            Instantiate(planePrefab[planeNumber], spawnlocation.position, spawnlocation.rotation, parentObject);

            moneyScrip.money -= planeCost[planeNumber];
            cheatWin++;
        }
    }

    public void ShipNumberChanger(int shipNumberPicked)
    {
        planeNumber = shipNumberPicked;
    }
}

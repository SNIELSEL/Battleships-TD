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
    public void Start()
    {
        moneyScrip = gameObject.GetComponent<Money>();
    }

    public void Update()
    {

    }

    public void SpawnPlane()
    {
        if (moneyScrip.money >= planeCost[planeNumber])
        {
            Instantiate(planePrefab[planeNumber], spawnlocation.position, spawnlocation.rotation, parentObject);

            moneyScrip.money -= planeCost[planeNumber];
        }
    }

    public void ShipNumberChanger(int shipNumberPicked)
    {
        planeNumber = shipNumberPicked;
    }
}

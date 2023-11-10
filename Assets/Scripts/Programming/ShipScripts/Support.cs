using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : ShipBaseScript
{
    [Header("Support")]
    public GameObject[] planes;
    public GameObject spawnlocation;

    public float spawnTimer;
    public float startSpawnTime;

    public int planeInt;
    public int planeToSpawn;
    public override void Start()
    {
        base.Start();

        startSpawnTime = spawnTimer;

        NewPlane();
    }

    public override void Update()
    {
        base.Update();

        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            spawnTimer = startSpawnTime;

            Instantiate(planes[planeToSpawn].transform, spawnlocation.transform.position, spawnlocation.transform.rotation);
        }
    }

    public void NewPlane()
    {
        if (!isEnemyTower)
        {
            planeInt = Random.Range(0, 11);

            if(planeInt <= 6)
            {
                planeToSpawn = 0;
            }
            else if(planeInt >= 7)
            {
                planeToSpawn = 1;
            }
        }
        else
        {
            planeInt = Random.Range(0, 11);

            if (planeInt <= 5)
            {
                planeToSpawn = 0;
            }
            else if (planeInt >= 6 && planeInt <= 9)
            {
                planeToSpawn = 1;
            }
            else if(planeInt == 10)
            {
                planeToSpawn = 2;
            }
        }
    }
}

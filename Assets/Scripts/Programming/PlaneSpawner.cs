using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public Transform[] spawnlocations;

    public GameObject[] planes;

    public int gameStage;

    public float[] planeSpawnTimer;
    public float[] beginPlaneSpawnTimer;
    public Vector2 planesToSpawn;
    public float gameTimer;
    public Vector2 locationSelector;
    public GameObject[] shipsOnBoard;
    public string[] shipIdentifiers;
    public int locationInt;
    public Transform parentObject;
    public int randomLoc;
    public FlagSchip flagSchip;
    void Start()
    {
        planeSpawnTimer[0] = 30;

        parentObject = GameObject.Find("PlanesParent").transform;

        gameTimer = 1800;

        for (int i = 0; i < beginPlaneSpawnTimer.Length; i++)
        {
            beginPlaneSpawnTimer[i] = planeSpawnTimer[i];
        }
    }

    void Update()
    {
        gameTimer -= Time.deltaTime;
        planeSpawnTimer[gameStage] -= Time.deltaTime;

        if(gameStage == 1)
        {
            planesToSpawn.y = 1;
        }
        else if(gameStage == 2)
        {
            planesToSpawn.y = 2;
        }

        if(gameTimer <= 1200 && gameStage != 2)
        {
            gameStage = 1;
        }
        else if(gameTimer <= 600)
        {
            gameStage = 2;
        }

        if (planeSpawnTimer[gameStage] <= 0 && flagSchip.flagShipSunk == false)
        {
            planeSpawnTimer[0] = 5;
            beginPlaneSpawnTimer[0] = 5;

            randomLoc = Random.Range(0, 2);

            Instantiate(planes[(int)Random.Range(planesToSpawn.x, planesToSpawn.y)], spawnlocations[randomLoc].transform.position, spawnlocations[randomLoc].transform.rotation, parentObject);

            for (int i = 0; i < planeSpawnTimer.Length; i++)
            {
                planeSpawnTimer[i] = beginPlaneSpawnTimer[i];
            }
        }
    }
}

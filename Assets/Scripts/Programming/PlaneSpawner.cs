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
    private GameObject[] shipChecker;
    public string[] shipIdentifiers;
    private int emptyShipCount;
    public int locationInt;
    void Start()
    {
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

        if (planeSpawnTimer[gameStage] <= 0)
        {
            ScanForShips();

            for (int i = 0; i < planeSpawnTimer.Length; i++)
            {
                planeSpawnTimer[i] = beginPlaneSpawnTimer[i];
            }

            if (shipsOnBoard[0] != null || shipsOnBoard[1] != null)
            {
                Instantiate(planes[(int)Random.Range(planesToSpawn.x, planesToSpawn.y)], spawnlocations[0].transform.position, spawnlocations[0].transform.rotation);
                locationInt = 0;
            }
            else if (shipsOnBoard[2] != null || emptyShipCount == 5)
            {
                Instantiate(planes[(int)Random.Range(planesToSpawn.x, planesToSpawn.y)], spawnlocations[1].transform.position, spawnlocations[1].transform.rotation);
                locationInt = 1;
            }
            else if (shipsOnBoard[3] != null || shipsOnBoard[4] != null)
            {
                Instantiate(planes[(int)Random.Range(planesToSpawn.x, planesToSpawn.y)], spawnlocations[2].transform.position, spawnlocations[2].transform.rotation);
                locationInt = 2;
            }

            emptyShipCount = 0;
        }
    }

    public void ScanForShips()
    {
        shipChecker = GameObject.FindGameObjectsWithTag("Ship");

        for (int i = 0; i < shipChecker.Length; i++)
        {
            if (shipChecker[i].GetComponent<ShipBaseScript>().shipIdentifyer == shipIdentifiers[0])
            {
                shipsOnBoard[0] = shipChecker[i];
            }
            else if (shipChecker[i].GetComponent<ShipBaseScript>().shipIdentifyer == shipIdentifiers[1])
            {
                shipsOnBoard[1] = shipChecker[i];
            }
            else if (shipChecker[i].GetComponent<ShipBaseScript>().shipIdentifyer == shipIdentifiers[2])
            {
                shipsOnBoard[2] = shipChecker[i];
            }
            else if (shipChecker[i].GetComponent<ShipBaseScript>().shipIdentifyer == shipIdentifiers[3])
            {
                shipsOnBoard[3] = shipChecker[i];
            }
            else if (shipChecker[i].GetComponent<ShipBaseScript>().shipIdentifyer == shipIdentifiers[4])
            {
                shipsOnBoard[4] = shipChecker[i];
            }
        }

        for (int i = 0; i < shipsOnBoard.Length; i++)
        {
            if (shipsOnBoard[i] == null)
            {
                emptyShipCount++;
            }
        }
    }
}

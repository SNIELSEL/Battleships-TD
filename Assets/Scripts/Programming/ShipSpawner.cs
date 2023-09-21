using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject[] shipsBottomLeft;
    public GameObject[] shipsBottomRight;
    public GameObject[] shipsMiddle;
    public GameObject[] shipsTopLeft;
    public GameObject[] shipsTopRight;

    [Header("GhostShips")]
    public string[] ghostShipTags;
    public GameObject[] ghostShipsBottomLeft;
    public GameObject[] ghostShipsBottomRight;
    public GameObject[] ghostShipsMiddle;
    public GameObject[] ghostShipsUpLeft;

    [Header("SpawnLocations/Rails")]
    public Transform[] shipSpawnLocations;
    public Transform[] ghostShipSpawnLocations;
    public Transform[] rails;
    public Transform[] Ghostrails;

    [Header("SelectorInts")]
    public int locationToSpawn;
    public int shipToSpawn;

    [Header("UI")]
    public GameObject[] shipSpawnUI;

    public void locationPicker(int locationNumber)
    {
       locationToSpawn = locationNumber;
    }
    public void shipPicker(int shipNumber)
    {
        shipSpawnUI[locationToSpawn].SetActive(false);
        shipToSpawn = shipNumber;
    }

    public void shipInstantiator()
    {
        if (locationToSpawn == 0)
        {
            Instantiate(ghostShipsBottomLeft[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsBottomLeft[shipToSpawn].transform.rotation);

            Instantiate(shipsBottomLeft[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsBottomLeft[shipToSpawn].transform.rotation);
        }
        else if(locationToSpawn == 1)
        {
            Instantiate(ghostShipsBottomRight[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsBottomRight[shipToSpawn].transform.rotation);

            Instantiate(shipsBottomRight[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsBottomRight[shipToSpawn].transform.rotation);
        }
        else if (locationToSpawn == 2)
        {
            Instantiate(ghostShipsMiddle[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsMiddle[shipToSpawn].transform.rotation);

            Instantiate(shipsMiddle[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsMiddle[shipToSpawn].transform.rotation);

        }
        else if (locationToSpawn == 3)
        {
            Instantiate(ghostShipsUpLeft[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsUpLeft[shipToSpawn].transform.rotation);

            Instantiate(shipsTopLeft[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, ghostShipsUpLeft[shipToSpawn].transform.rotation);
        }
        else if (locationToSpawn == 4)
        {
            Instantiate(shipsTopRight[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsTopRight[shipToSpawn].transform.rotation);
        }
    }
}

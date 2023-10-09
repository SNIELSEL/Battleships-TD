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
    public Transform parentObject;

    [Header("SelectorInts")]
    public int locationToSpawn;
    public int shipToSpawn;

    [Header("UI")]
    public GameObject[] shipSpawnUI;

    public Money moneycript;

    private void Start()
    {
        parentObject = GameObject.Find("ShipParent").transform;
    }

    public void locationPicker(int locationNumber)
    {
       locationToSpawn = locationNumber;
    }
    public void shipPicker(int shipNumber)
    {
        shipToSpawn = shipNumber;
    }

    public void shipInstantiator()
    {
        shipSpawnUI[locationToSpawn].SetActive(false);
        if (locationToSpawn == 0)
        {
            Instantiate(ghostShipsBottomLeft[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsBottomLeft[shipToSpawn].transform.rotation,parentObject);

            Instantiate(shipsBottomLeft[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsBottomLeft[shipToSpawn].transform.rotation,parentObject);
        }
        else if(locationToSpawn == 1)
        {
            Instantiate(ghostShipsBottomRight[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsBottomRight[shipToSpawn].transform.rotation,parentObject);

            Instantiate(shipsBottomRight[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsBottomRight[shipToSpawn].transform.rotation,parentObject);
        }
        else if (locationToSpawn == 2)
        {
            Instantiate(ghostShipsMiddle[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsMiddle[shipToSpawn].transform.rotation,parentObject);

            Instantiate(shipsMiddle[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsMiddle[shipToSpawn].transform.rotation,parentObject);

        }
        else if (locationToSpawn == 3)
        {
            Instantiate(ghostShipsUpLeft[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsUpLeft[shipToSpawn].transform.rotation,parentObject);

            Instantiate(shipsTopLeft[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, ghostShipsUpLeft[shipToSpawn].transform.rotation,parentObject);
        }
        else if (locationToSpawn == 4)
        {
            Instantiate(shipsTopRight[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsTopRight[shipToSpawn].transform.rotation,parentObject);
        }
    }

    public void BuyShip()
    {
        if(shipToSpawn == 0)
        {
            moneycript.money -= 1000;
        }
        else if (shipToSpawn == 1)
        {
            moneycript.money -= 2500;
        }
        else if (shipToSpawn == 2)
        {
            moneycript.money -= 3000;
        }
        else if (shipToSpawn == 3)
        {
            moneycript.money -= 4000;
        }
    }

}

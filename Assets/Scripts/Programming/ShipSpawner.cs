using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Color startColor;
    public Color noMoneyColor;

    public Button[] shipLocationButton;
    public GameObject[] shipSpawnUI;
    public string[] buttontext;

    public Money moneycript;
    public int[] spawnCost;

    public GameObject[] shipsSpawnedIn;
    public GameObject[] enemyShips;
    public GameObject enemyBase;
    public GameObject enemyTarget;

    private bool[] shipRespawning;
    private int uiForCountDown;
    private float[] respawnTime;
    private string[] shipIDs;

    private bool[] shipchecks;

    private void Start()
    {
        shipchecks = new bool[5];

        shipIDs = new string[] { "BL", "BR", "M", "UL", "UR" };
        parentObject = GameObject.Find("ShipParent").transform;

        respawnTime = new float[] {60,60,60,60,60};
        shipRespawning = new bool[5];
    }

    public void Update()
    {
        ShipRespawnTimer();
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
        if(moneycript.money >= spawnCost[shipToSpawn])
        {
            BuyShip();

            shipSpawnUI[locationToSpawn].GetComponent<TextMeshProUGUI>().text = "On  Duty";
            shipLocationButton[locationToSpawn].interactable = false;
            if (locationToSpawn == 0)
            {
                Instantiate(ghostShipsBottomLeft[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsBottomLeft[shipToSpawn].transform.rotation, parentObject);

                Instantiate(shipsBottomLeft[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsBottomLeft[shipToSpawn].transform.rotation, parentObject);
            }
            else if (locationToSpawn == 1)
            {
                Instantiate(ghostShipsBottomRight[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsBottomRight[shipToSpawn].transform.rotation, parentObject);

                Instantiate(shipsBottomRight[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsBottomRight[shipToSpawn].transform.rotation, parentObject);
            }
            else if (locationToSpawn == 2)
            {
                Instantiate(ghostShipsMiddle[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsMiddle[shipToSpawn].transform.rotation, parentObject);

                Instantiate(shipsMiddle[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsMiddle[shipToSpawn].transform.rotation, parentObject);

            }
            else if (locationToSpawn == 3)
            {
                Instantiate(ghostShipsUpLeft[shipToSpawn], ghostShipSpawnLocations[locationToSpawn].transform.position, ghostShipsUpLeft[shipToSpawn].transform.rotation, parentObject);

                Instantiate(shipsTopLeft[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, ghostShipsUpLeft[shipToSpawn].transform.rotation, parentObject);
            }
            else if (locationToSpawn == 4)
            {
                Instantiate(shipsTopRight[shipToSpawn], shipSpawnLocations[locationToSpawn].transform.position, shipsTopRight[shipToSpawn].transform.rotation, parentObject);
            }
        }
        else
        {
            StartCoroutine(NotEnoughMoney());
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

    public void ShipRespawnTimer(float respawntime, string shipid)
    {
        for (int i = 0; i < shipIDs.Length; i++)
        {
            if(shipIDs[i] == shipid)
            {
                shipRespawning[i] = true;
                uiForCountDown = i;
            }
        }

        for (int i = 0; i < shipchecks.Length; i++)
        {
            if(i == uiForCountDown)
            {
                shipchecks[i] = true;
            }
        }

        respawnTime[uiForCountDown] = respawntime;
    }

    public void ShipRespawnTimer()
    {
        if (shipRespawning[0])
        {
            if (shipchecks[0] == true)
            {
                respawnTime[0] -= Time.deltaTime;
                shipSpawnUI[0].GetComponent<TextMeshProUGUI>().text = "Respawning... " + (int)respawnTime[0];
            }
        }
        if (shipRespawning[1])
        {
            if (shipchecks[1] == true)
            {
                respawnTime[1] -= Time.deltaTime;
                shipSpawnUI[1].GetComponent<TextMeshProUGUI>().text = "Respawning... " + (int)respawnTime[1];
            }
        }
        if (shipRespawning[2])
        {
            if (shipchecks[2] == true)
            {
                respawnTime[2] -= Time.deltaTime;
                shipSpawnUI[2].GetComponent<TextMeshProUGUI>().text = "Respawning... " + (int)respawnTime[2];
            }
        }
        if (shipRespawning[3])
        {
            if (shipchecks[3] == true)
            {
                respawnTime[3] -= Time.deltaTime;
                shipSpawnUI[3].GetComponent<TextMeshProUGUI>().text = "Respawning... " + (int)respawnTime[3];
            }
        }
        if (shipRespawning[4])
        {
            if (shipchecks[4] == true)
            {
                respawnTime[4] -= Time.deltaTime;
                shipSpawnUI[4].GetComponent<TextMeshProUGUI>().text = "Respawning... " + (int)respawnTime[4];
            }
        }

        for (int i = 0; i < respawnTime.Length; i++)
        {
            if (respawnTime[i] <= 0)
            {
                if (shipchecks[i] == true)
                {
                    respawnTime[i] = 60;
                    shipchecks[i] = false;
                    shipRespawning[i] = false;
                    shipSpawnUI[i].GetComponent<TextMeshProUGUI>().text = buttontext[i];
                    shipLocationButton[i].interactable = true;
                }
            }
        }
    }

    public IEnumerator NotEnoughMoney()
    {
        moneycript.hUDMoneyText.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        moneycript.hUDMoneyText.color = Color.yellow;
    }

}

using Bitgem.VFX.StylisedWater;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyTargetNav : MonoBehaviour
{
    public ShipSpawner shipSpawner;
    public GameObject[] enemyShips = new GameObject[5];
    public GameObject[] enemyShipTargets = new GameObject[5];

    public GameObject halfwayMark;
    public GameObject EndPoint;

    private int destinationNumber;

    private bool overHalfwayMark;
    private bool droppedBomb;

    public void Start()
    {
        halfwayMark = GameObject.Find("HalfWayMark");
        EndPoint = GameObject.Find("EndPoint");

        destinationNumber = Random.Range(0, 5);

        ComponentAssigner();

        enemyShips = shipSpawner.enemyShips;

        for (int i = 0; i < enemyShips.Length; i++)
        {
            if (enemyShips[i] != null)
            {
                enemyShipTargets[i] = enemyShips[i].transform.Find("EnemyTarget").gameObject;
            }
        }
    }

    public void ComponentAssigner()
    {
        shipSpawner = GameObject.Find("ScriptManager").GetComponent<ShipSpawner>();
    }

    private void Update()
    {
        if (enemyShips[destinationNumber].GetComponent<ShipBaseScript>() == null)
        {
            if(enemyShips.Length == 1)
            {
                destinationNumber = Random.Range(1, 1);
            }
            else
            {
                destinationNumber = Random.Range(0, 5);
            }
        }

        if (enemyShips[destinationNumber].GetComponent<ShipBaseScript>().shipSunk)
        {
            if (enemyShips.Length == 1)
            {
                destinationNumber = Random.Range(1, 1);
            }
            else
            {
                destinationNumber = Random.Range(0, 5);
            }
        }
       
        if (Vector3.Distance(transform.position, halfwayMark.transform.position) <= 2)
        {
            overHalfwayMark = true;
        }

        if (Vector3.Distance(transform.position, enemyShipTargets[destinationNumber].transform.position) <= 2)
        {
            overHalfwayMark = false;
            droppedBomb = true;
        }

        if (overHalfwayMark && !droppedBomb)
        {
            transform.LookAt(enemyShipTargets[destinationNumber].transform);
            transform.position = Vector3.MoveTowards(transform.position, enemyShipTargets[destinationNumber].transform.position, GetComponent<BasePlane>().speed * Time.deltaTime);
        }
        else if (!droppedBomb)
        {
            transform.LookAt(halfwayMark.transform);
            transform.position = Vector3.MoveTowards(transform.position, halfwayMark.transform.position, GetComponent<BasePlane>().speed * Time.deltaTime);
        }

        if (droppedBomb)
        {
            transform.LookAt(EndPoint.transform);
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, GetComponent<BasePlane>().speed * Time.deltaTime);
        }
    }
}

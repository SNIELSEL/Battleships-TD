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
    public GameObject baseTower;
    public GameObject baseTarget;

    private int destinationNumber;
    private int emptyShip;

    private bool noships;
    private bool overHalfwayMark;
    private bool droppedBomb;

    public void Start()
    {
        ComponentAssigner();

        baseTarget = shipSpawner.enemyTarget;
        baseTower = shipSpawner.enemyBase;

        halfwayMark = GameObject.Find("HalfWayMark");
        EndPoint = GameObject.Find("EndPoint");

        destinationNumber = Random.Range(0, 5);


        enemyShips = shipSpawner.enemyShips;

        for (int i = 0; i < enemyShips.Length; i++)
        {
            if (enemyShips[i] != null)
            {
                enemyShipTargets[i] = enemyShips[i].transform.Find("EnemyTarget").gameObject;
            }
        }


        for (int i = 0; i < enemyShips.Length; i++)
        {
            if (enemyShips[i] == null)
            {
                emptyShip++;
            }
        }

        if (enemyShips.Length == 1)
        {
            destinationNumber = Random.Range(1, 1);
        }
        else
        {
            destinationNumber = Random.Range(0, enemyShips.Length - 1);
        }
    }

    public void ComponentAssigner()
    {
        shipSpawner = GameObject.Find("ScriptManager").GetComponent<ShipSpawner>();
    }

    private void Update()
    {

        if(emptyShip >= enemyShips.Length)
        {
            noships = true;
        }

        if (enemyShips[destinationNumber] == null)
        {
            destinationNumber++;
        }


        if (Vector3.Distance(transform.position, halfwayMark.transform.position) <= 2)
        {
            overHalfwayMark = true;
        }

        if (!noships)
        {
            if (Vector3.Distance(transform.position, enemyShipTargets[destinationNumber].transform.position) <= 2)
            {
                overHalfwayMark = false;
                droppedBomb = true;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, baseTarget.transform.position) <= 2)
            {
                overHalfwayMark = false;
                droppedBomb = true;
            }
        }

        if (!noships)
        {
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
        }
        else
        {
            if (overHalfwayMark && !droppedBomb)
            {
                transform.LookAt(baseTarget.transform);
                transform.position = Vector3.MoveTowards(transform.position, baseTarget.transform.position, GetComponent<BasePlane>().speed * Time.deltaTime);
            }
            else if (!droppedBomb)
            {
                transform.LookAt(halfwayMark.transform);
                transform.position = Vector3.MoveTowards(transform.position, halfwayMark.transform.position, GetComponent<BasePlane>().speed * Time.deltaTime);
            }
        }

        if (droppedBomb)
        {
            transform.LookAt(EndPoint.transform);
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, GetComponent<BasePlane>().speed * Time.deltaTime);
        }
    }
}

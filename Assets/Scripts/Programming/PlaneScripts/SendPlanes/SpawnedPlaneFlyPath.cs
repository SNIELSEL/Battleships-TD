using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedPlaneFlyPath : MonoBehaviour
{
    public int destinationNumber;
    public Transform[] destination;

    private BasePlane planeStats;

    public void Start()
    {
        planeStats = gameObject.GetComponent<BasePlane>();

        destination[0] = GameObject.Find("AllyPath1").transform;
        destination[1] = GameObject.Find("AllyPath2").transform;
        destination[2] = GameObject.Find("AllyPath3").transform;
    }

    public void Update()
    {
        if (Vector3.Distance(transform.position, destination[0].position) <= 2 && destinationNumber == 0)
        {
            destinationNumber = 1;
        }
        else if (Vector3.Distance(transform.position, destination[1].position) <= 2 && destinationNumber == 1)
        {
            destinationNumber = 2;
        }

        if (destinationNumber == 0)
        {
            transform.LookAt(destination[destinationNumber]);
            transform.position = Vector3.MoveTowards(transform.position, destination[0].position, planeStats.speed * Time.deltaTime);
        }
        else if (destinationNumber == 1)
        {
            transform.LookAt(destination[destinationNumber]);
            transform.position = Vector3.MoveTowards(transform.position, destination[1].position, planeStats.speed * Time.deltaTime);
        }
        else if (destinationNumber == 2)
        {
            transform.LookAt(destination[destinationNumber]);
            transform.position = Vector3.MoveTowards(transform.position, destination[2].position, planeStats.speed * Time.deltaTime);
        }
    }
}

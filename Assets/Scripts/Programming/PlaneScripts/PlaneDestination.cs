using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneDestination : MonoBehaviour
{
    private Transform[] destinations;
    private Transform[] endDestinations;

    private Vector3 position;
    private int pathNumber;

    private BasePlane planeStats;
    private PlaneSpawner spawner;
    private int destinationNumber;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Keep").GetComponent<PlaneSpawner>();
        planeStats = gameObject.GetComponent<BasePlane>();

        pathNumber = spawner.locationInt;

        position = transform.position;

        destinations = new Transform[3];
        destinations[0] = GameObject.Find("BombDrop1 ACC").transform;
        destinations[1] = GameObject.Find("BombDrop2 ACC").transform;
        destinations[2] = GameObject.Find("BombDrop3 ACC").transform;

        endDestinations = new Transform[3];
        endDestinations[0] = GameObject.Find("End ACC 1").transform;
        endDestinations[1] = GameObject.Find("End ACC 2").transform;
        endDestinations[2] = GameObject.Find("End ACC 3").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, destinations[pathNumber].position) <= 3 && destinationNumber == 0)
        {
            destinationNumber = 1;
        }

        //destination to go to
        if(destinationNumber == 0)
        {
            transform.LookAt(destinations[pathNumber]);
            transform.position = Vector3.MoveTowards(transform.position, destinations[pathNumber].position, planeStats.speed * Time.deltaTime);
        }
        else if(destinationNumber == 1)
        {
            transform.LookAt(endDestinations[pathNumber]);
            transform.position = Vector3.MoveTowards(transform.position, endDestinations[pathNumber].position, planeStats.speed * Time.deltaTime);
        }
    }
}

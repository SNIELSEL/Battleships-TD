using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneDestination : MonoBehaviour
{
    public Transform[] destinations;


    private Vector3 position;
    private int pathNumber;

    private BasePlane planeStats;
    private PlaneSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Keep").GetComponent<PlaneSpawner>();
        planeStats = gameObject.GetComponent<BasePlane>();

        pathNumber = spawner.locationInt;

        position = transform.position;

        destinations[0] = GameObject.Find("BombDrop1 ACC").transform;
        destinations[1] = GameObject.Find("BombDrop2 ACC").transform;
        destinations[2] = GameObject.Find("BombDrop3 ACC").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinations[pathNumber].position, planeStats.speed * Time.deltaTime);

        transform.LookAt(destinations[pathNumber]);
    }
}

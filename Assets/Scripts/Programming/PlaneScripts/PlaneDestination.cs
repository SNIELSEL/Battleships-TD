using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDestination : MonoBehaviour
{
    public Transform[] destinations;


    private Vector3 position;
    private int pathNumber;
    // Start is called before the first frame update
    void Start()
    {
        pathNumber = Random.Range(0, 2);

        position = transform.position;

        destinations[0] = GameObject.Find("FlyPoint1").transform;
        destinations[1] = GameObject.Find("FlyPoint2").transform;
        destinations[2] = GameObject.Find("FlyPoint3").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = position;

        transform.LookAt(destinations[pathNumber]);
    }
}

using Bitgem.VFX.StylisedWater;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Boatnavigation : MonoBehaviour
{
    public NavMeshAgent agent;

    public List<Transform> destinations;
    public Transform parentObject;
    public Transform LookatTransform;

    public string waypointTag;

    public float rotationTime;

    public bool isGhostShip;

    private int currentDestination;

    ShipSpawner shipSpawner;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<WateverVolumeFloater>().enabled = false;
        shipSpawner = GameObject.Find("Keep").GetComponent<ShipSpawner>();

        if (!isGhostShip && LookatTransform == null && shipSpawner.locationToSpawn != 4)
        {
            LookatTransform = GameObject.FindWithTag(shipSpawner.ghostShipTags[shipSpawner.locationToSpawn]).transform;
        }

        if (parentObject == null && !isGhostShip)
        {
            parentObject = shipSpawner.rails[shipSpawner.locationToSpawn];
        }
        else if (parentObject == null && isGhostShip)
        {
            parentObject = shipSpawner.Ghostrails[shipSpawner.locationToSpawn];
        }

        agent = GetComponent<NavMeshAgent>();
        
        for(int i = 0; i < parentObject.childCount; i++)
        {
            destinations.Add(parentObject.GetChild(i));
        }

        agent.destination = destinations[currentDestination].position;
    }

    void Update()
    {
        if (!isGhostShip)
        {
            transform.LookAt(LookatTransform);
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == waypointTag)
        {
            currentDestination++;


            if (destinations.Count >= currentDestination + 1)
            {
                agent.destination = destinations[currentDestination].position;
            }
            else
            {
                StartCoroutine(DisengageGhost());
            }
        }
    }

    public IEnumerator DisengageGhost()
    {
        yield return new WaitForSeconds(5);
        //transform.rotation = new Quaternion(0, 0, 0, 0);
        this.GetComponent<WateverVolumeFloater>().WaterVolumeHelper = GameObject.FindGameObjectWithTag("WaterLayer").GetComponent<WaterVolumeHelper>();
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        gameObject.GetComponent<Boatnavigation>().enabled = false;
        this.GetComponent<WateverVolumeFloater>().enabled = true;

        if (isGhostShip)
        {
            Destroy(gameObject);
        }
    }
}


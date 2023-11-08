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
        GetComponent<WateverVolumeFloater>().enabled = false;
        shipSpawner = GameObject.Find("ScriptManager").GetComponent<ShipSpawner>();

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
        transform.rotation = new quaternion(0, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        GetComponent<WateverVolumeFloater>().WaterVolumeHelper = GameObject.FindGameObjectWithTag("WaterLayer").GetComponent<WaterVolumeHelper>();
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Boatnavigation>().enabled = false;
        GetComponent<WateverVolumeFloater>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;

        if (isGhostShip)
        {
            Destroy(gameObject);
        }
    }
}


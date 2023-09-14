using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Boatnavigation : MonoBehaviour
{

    public Transform firstDestination;
    public Transform secondDestination;
    public Transform finalDestination;
    public Transform lookatPoint;
    public NavMeshAgent agent;

    private bool hasReachedFirstDestination;
    private bool hasReachedSecondDestination;
    private bool hasReachedFinalDestination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasReachedFirstDestination)
        {
            agent.destination = firstDestination.position;
        }
        else if(hasReachedFirstDestination && !hasReachedSecondDestination)
        {
            agent.destination = secondDestination.position;
        }
        else if(hasReachedSecondDestination && !hasReachedFinalDestination)
        {
            agent.destination = finalDestination.position;
        }

        transform.LookAt(lookatPoint);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "FirstDestination")
        {
            hasReachedFirstDestination = true;
        }

        if (collision.gameObject.tag == "SecondDestination")
        {
            hasReachedSecondDestination = true;
        }

        if (collision.gameObject.tag == "FinalDestination")
        {
            hasReachedFinalDestination = true;
        }
    }
}

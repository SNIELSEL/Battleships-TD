using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFov : MonoBehaviour
{
    [Header("DetectionStats")]
    public float Objectscanradius;
    private float nearestDistance = 10000;
    public float radius;
    [Range(0, 360f)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    public void Start()
    {
        StartCoroutine(ScanForPlanes());
    }

    private IEnumerator ScanForPlanes()
    {
        yield return new WaitForSeconds(1);

        StartCoroutine(FOVRoutine());
        detectEnemy();

        StartCoroutine(ScanForPlanes());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else if (!playerRef)
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }

    public void detectEnemy()
    {
        if (nearestDistance < 200)
        {
            nearestDistance = 10000;
        }

         GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Target");
         for (int i = 0; i < allObjects.Length; i++)
         {
            Objectscanradius = Vector3.Distance(this.transform.position, allObjects[i].transform.position);
             if (Objectscanradius < nearestDistance)
            {
                playerRef = allObjects[i];
                nearestDistance = Objectscanradius;
            }
            else if(canSeePlayer)
            {
                canSeePlayer = false;
            }
         }
    }
}

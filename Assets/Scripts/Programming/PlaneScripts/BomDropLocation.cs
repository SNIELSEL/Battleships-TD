using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomDropLocation : MonoBehaviour
{
    private BasePlane _plane;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            _plane = other.GetComponent<BasePlane>();

            _plane.isAttacking = true;
        }
    }
}

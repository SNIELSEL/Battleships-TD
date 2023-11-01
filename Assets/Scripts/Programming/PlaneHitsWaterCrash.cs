using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHitsWaterCrash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Target")
        {
            other.gameObject.GetComponent<BasePlane>().Explode();
        }

        if(other.gameObject.tag == "Ammo")
        {
            Destroy(other.gameObject);
        }
    }
}

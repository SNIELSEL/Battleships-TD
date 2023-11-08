using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDetection : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] planes;
    public void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Target")
        {
            enemy = other.gameObject;
        }

        /*planes = new GameObject[planes.Length + 1];
        
        if (planes[0] == null)
        {

        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        enemy = null;
    }
}

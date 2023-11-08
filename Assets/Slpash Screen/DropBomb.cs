using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropBomb : MonoBehaviour
{
    public bool dropBom = false;

    public Vector3 bomMovement;
    public float bomSpeed;

    public string bomDropScreen;

    public void Update()
    {
        DropBom();
    }
    public void OnTriggerEnter(Collider other)
    {
        dropBom = true;
    }

    public void DropBom()
    {
        if (dropBom == true)
        {
            bomMovement.z = bomSpeed;

            transform.Translate(bomMovement * Time.deltaTime);
        }
    }

}

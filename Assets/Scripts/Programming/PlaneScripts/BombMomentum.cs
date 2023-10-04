using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombMomentum : MonoBehaviour
{
    public int bombSpeed;
    public GameObject[] bombLoc;

    public PlaneSpawner planeSpawner;

    public void Start()
    {
        planeSpawner = GameObject.Find("Keep").GetComponent<PlaneSpawner>();

        bombLoc[0] = GameObject.Find("BombPath1");
        bombLoc[1] = GameObject.Find("BombPath2");
        bombLoc[2] = GameObject.Find("BombPath3");
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, bombLoc[planeSpawner.locationInt].transform.position, bombSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ship" || collision.gameObject.tag == "PlaneCarrier")
        {
            //scollision.gameObject.GetComponent<ShipBaseScript>().health -= 
        }
    }
}

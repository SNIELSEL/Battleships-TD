using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombMomentum : MonoBehaviour
{
    public int bombSpeed;
    public GameObject[] bombLoc;

    public PlaneSpawner planeSpawner;

    public int damage;

    public ParticleSystem explosion;

    public Transform parentObject;
    public void Start()
    {
        parentObject = GameObject.Find("ParticleParent").transform;

        planeSpawner = GameObject.Find("ScriptManager").GetComponent<PlaneSpawner>();

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
            gameObject.SetActive(false);
            Instantiate(explosion, transform.position, transform.rotation, parentObject);

            if(collision.gameObject.GetComponent<ShipBaseScript>().armor <= 0)
            {
                collision.gameObject.GetComponent<ShipBaseScript>().health -= damage;
            }
            else
            {
                collision.gameObject.GetComponent<ShipBaseScript>().armor -= damage;
            }

            Destroy(this.gameObject);
        }
    }
}

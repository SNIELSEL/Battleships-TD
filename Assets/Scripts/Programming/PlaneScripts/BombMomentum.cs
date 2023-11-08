using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BombMomentum : MonoBehaviour
{
    public int bombSpeed;
    public GameObject[] bombLoc;
    public GameObject closestObject;

    public PlaneSpawner planeSpawner;

    public int damage;

    public ParticleSystem explosion;

    public Transform parentObject;

    private float distance;
    private float lowestDistance;

    public bool isEnemy;

    public void Start()
    {
        lowestDistance = Mathf.Infinity;

        parentObject = GameObject.Find("ParticleParent").transform;

        planeSpawner = GameObject.Find("ScriptManager").GetComponent<PlaneSpawner>();

        if (isEnemy)
        {
            bombLoc = GameObject.FindGameObjectsWithTag("EnemyShip");
        }
        else if (!isEnemy)
        {
            bombLoc = GameObject.FindGameObjectsWithTag("Ship");
        }

        for (int i = 0; i < bombLoc.Length; i++)
        {
            distance = Vector3.Distance(bombLoc[i].transform.position, transform.position);

            if (distance < lowestDistance)
            {
                lowestDistance = distance;
                closestObject = bombLoc[i];
            }
        }

        if (bombLoc[0] == null)
        {
            bombLoc = new GameObject[1];

            closestObject = GameObject.FindGameObjectWithTag("PlaneCarrier");
        }
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, closestObject.transform.position, bombSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ship" || collision.gameObject.tag == "PlaneCarrier" || collision.gameObject.tag == "EnemyShip")
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

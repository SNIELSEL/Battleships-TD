using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    private bool attackingBase;

    private float x;

    public void Start()
    {
        lowestDistance = Mathf.Infinity;

        parentObject = GameObject.Find("ParticleParent").transform;

        planeSpawner = GameObject.Find("ScriptManager").GetComponent<PlaneSpawner>();

        if (isEnemy)
        {
            bombLoc = GameObject.FindGameObjectsWithTag("EnemyShip");
            bombLoc = GameObject.FindGameObjectsWithTag("EnemyBase");
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

        StartCoroutine(NoObjectFix());
    }

    public IEnumerator NoObjectFix()
    {
        yield return new WaitForSeconds(0.1f);

        if (bombLoc.Length == 0)
        {
            attackingBase = true;
        }
    }
    private void Update()
    {
        x = transform.position.x;

        if (!attackingBase)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestObject.transform.position, bombSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x -= 0.05f, transform.position.y,transform.position.z), bombSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ship" || collision.gameObject.tag == "PlaneCarrier" || collision.gameObject.tag == "EnemyShip" || collision.gameObject.tag == "EnemyBase")
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

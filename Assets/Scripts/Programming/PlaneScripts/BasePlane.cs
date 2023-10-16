using Bitgem.VFX.StylisedWater;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BasePlane : MonoBehaviour
{
    [Header("PlaneInfo")]
    public string planeName;
    public string planeClass;
    public string description;
    public string type;
    public GameObject projectile;
    private GameObject spawnedProjectile;

    [Header("stats")]
    public float health;
    public Vector2 damage;
    public float attackSpeed;
    public float armor;
    public int speed;
    public int ammo;

    public bool isAttacking;
    public Transform parentObject;
    public Transform bombObject;
    public bool isAttacker;
    public ParticleSystem explosion;

    //private info
    private Transform[] destinations;
    private Transform[] endDestinations;
    private string[] identifiers = new string[] { "BL", " BR", "M", "UL", "UR" };

    private int pathNumber;
    private float beginAttackSpeed;

    private BasePlane planeStats;
    private PlaneSpawner spawner;
    private int destinationNumber;

    private FlagSchip flagSchip;
    private Money moneyScript;
    private bool isDead;
    private bool planeNavStarted;
    private bool allShipsDestroyed;
    public void Start()
    {
        moneyScript = GameObject.Find("ScriptManager").GetComponent<Money>();

        flagSchip = GameObject.Find("akagi").GetComponent<FlagSchip>();

        bombObject = GameObject.Find("ParticleParent").transform;

        parentObject = GameObject.Find("BombParent").transform;

        PlaneNavegation();
    }

    public void Update()
    {
        PlaneNavegation();

        if (health <= 0 && !isDead)
        {
            isDead = true;
            Instantiate(explosion, transform.position, transform.rotation, bombObject);

            moneyScript.money += 100;
            Destroy(gameObject);

            Debug.Log("dead");
        }

        if (ammo > 0 && isAttacking)
        {
            ammo--;

            spawnedProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            spawnedProjectile.GetComponent<BombMomentum>().damage = (int)Random.Range(damage.x,damage.y);

        }
    }

    public void PlaneNavegation()
    {
        //plane nav
        if (isAttacker && !planeNavStarted)
        {
            if (flagSchip.flagShipSunk)
            {
                destinationNumber = 1;
            }

            planeNavStarted = true;

            spawner = GameObject.Find("ScriptManager").GetComponent<PlaneSpawner>();
            planeStats = gameObject.GetComponent<BasePlane>();

            pathNumber = spawner.randomLoc;

            if (allShipsDestroyed) 
            {
                destinations = new Transform[2];
                destinations[0] = GameObject.Find("BombDrop1 ACC").transform;
                destinations[1] = GameObject.Find("BombDrop2 ACC").transform;

                endDestinations = new Transform[2];
                endDestinations[0] = GameObject.Find("End ACC 1").transform;
                endDestinations[1] = GameObject.Find("End ACC 2").transform;
            }
        }

        //plane nav
        if (isAttacker)
        {
            if (Vector3.Distance(transform.position, destinations[pathNumber].position) <= 3 && destinationNumber == 0)
            {
                destinationNumber = 1;
            }

            //destination to go to
            if (destinationNumber == 0)
            {
                transform.LookAt(destinations[pathNumber]);
                transform.position = Vector3.MoveTowards(transform.position, destinations[pathNumber].position, planeStats.speed * Time.deltaTime);
            }
            else if (destinationNumber == 1)
            {
                transform.LookAt(endDestinations[pathNumber]);
                transform.position = Vector3.MoveTowards(transform.position, endDestinations[pathNumber].position, planeStats.speed * Time.deltaTime);
            }
        }
    }
}

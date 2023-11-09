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
    public int nonRandomDmg;
    public float attackSpeed;
    public float armor;
    public int speed;
    public int ammo;
    public int destroyReward;
    public int distanceFromDestination;

    public Transform parentObject;
    public Transform bombObject;
    public ParticleSystem explosion;
    public bool isAttacking;
    public bool isAttacker;
    public GameObject[] sortedShips;
    public List<GameObject> shipCheck;

    //private info
    private Transform[] destinations;
    private Transform[] endDestinations;
    private Transform target1;
    private Transform target2;

    private int destinationNumber;
    private int pathNumber;
    private int shipToAttack1;
    private int shipToAttack2;

    private bool isDead;
    private bool planeNavStarted;
    private bool noTowers;

    private BasePlane planeStats;
    private PlaneSpawner planeSpawner;
    private FlagSchip flagSchip;
    private Money moneyScript;
    private ShipSpawner shipSpawner;
    private bool shot;

    public void Start()
    {
        nonRandomDmg = (int)Random.Range(damage.x, damage.y);

        ComponentAssigner();
        TowerScan();
        PlaneNavegation();
    }

    public void Update()
    {
        PlaneNavegation();

        if (health <= 0 && !isDead)
        {
            Explode();
        }

        if (ammo > 0 && isAttacking && !flagSchip.flagShipSunk && !shot)
        {
            shot = true;
            ammo--;

            spawnedProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            spawnedProjectile.GetComponent<BombMomentum>().damage = nonRandomDmg;

            StartCoroutine(ShootingCoolDown());
        }
    }

    public IEnumerator ShootingCoolDown()
    {
        yield return new WaitForSeconds(0.1f);
        shot = false;
    }

    public void PlaneNavegation()
    {
        if (isAttacker && !planeNavStarted)
        {
            planeNavStarted = true;
            
            if (flagSchip.flagShipSunk)
            {
                destinationNumber = 1;
            }

            pathNumber = planeSpawner.randomLoc;

            if (noTowers)
            {
                destinations = new Transform[2];
                destinations[0] = target1;
                destinations[1] = target2;
            }

            endDestinations = new Transform[2];
            endDestinations[0] = GameObject.Find("End ACC 1").transform;
            endDestinations[1] = GameObject.Find("End ACC 2").transform;

            StartCoroutine(CheckDestination());
        }

        //plane nav
        if (isAttacker)
        {
            if (Vector3.Distance(transform.position, destinations[pathNumber].position) <= distanceFromDestination && destinationNumber == 0)
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

    public void TowerScan()
    {
        sortedShips = new GameObject[5];
        for (int i = 0; i < sortedShips.Length; i++)
        {
            if (shipSpawner.shipsSpawnedIn[i] != null)
            {
                sortedShips[i] = shipSpawner.shipsSpawnedIn[i];
            }
        }

        for (int i = 0; i < sortedShips.Length; i++)
        {
            if (sortedShips[i] != null && sortedShips[i].GetComponent<ShipBaseScript>().shipSunk == false)
            {
                shipCheck.Add(sortedShips[i]);
            }
        }

        if (shipCheck.Count <= 0)
        {
            noTowers = true;

            target1 = GameObject.Find("BombDrop1 ACC").transform;
            target2 = GameObject.Find("BombDrop2 ACC").transform;
        }
        else
        {
            destinations = new Transform[2];

            shipToAttack1 = Random.Range(0, shipCheck.Count);
            shipToAttack2 = Random.Range(0, shipCheck.Count);

            destinations[0] = shipCheck[shipToAttack1].transform.Find("Target");
            destinations[1] = shipCheck[shipToAttack2].transform.Find("Target");
        }
    }

    public void ComponentAssigner()
    {
        planeSpawner = GameObject.Find("ScriptManager").GetComponent<PlaneSpawner>();

        planeStats = gameObject.GetComponent<BasePlane>();

        shipSpawner = GameObject.Find("ScriptManager").GetComponent<ShipSpawner>();

        moneyScript = GameObject.Find("ScriptManager").GetComponent<Money>();

        flagSchip = GameObject.Find("akagi").GetComponent<FlagSchip>();

        bombObject = GameObject.Find("ParticleParent").transform;

        parentObject = GameObject.Find("BombParent").transform;
    }

    public void Explode()
    {
        isDead = true;
        Instantiate(explosion, transform.position, transform.rotation, bombObject);

        moneyScript.money += destroyReward;
        Destroy(gameObject);
    }

    public IEnumerator CheckDestination()
    {
        yield return new WaitForSeconds(1);

        if (destinations[0] == null || destinations[1] == null)
        {
            Explode();
        }

        StartCoroutine(CheckDestination());
    }
}

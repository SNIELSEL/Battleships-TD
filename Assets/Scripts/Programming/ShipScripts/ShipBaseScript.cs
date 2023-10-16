using Bitgem.VFX.StylisedWater;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class ShipBaseScript : MonoBehaviour
{
    [Header("ShipInfo")]
    public string shipName;
    public string ShipClass;
    public string description;
    public string type;
    public string shipIdentifyer;

    [Header("stats")]
    public float health;
    public Vector2 damage;
    public float attackSpeed;
    public float armor;
    public int speed;

    [Header("Etc")]
    public int respawnTime;
    public int sinkTime;
    public GunFov gunFov;
    public Transform cannonParent;
    public List<Transform> cannons;
    public GameObject shootEffect;
    public int destroyedShipMoney;

    //namedisplay
    public Canvas nameDisplay;

    //Private variables
    private TextMeshProUGUI nameText;
    private string[] names = new string[] { "3D Waffle", "Unsinkable", "Hightower", "101", "Houston", "GatlingGun", "Accidental Genius", "Prometheus", "Psycho, Pusher", "Junkyard Dog", "Roadblock", "Rooster", "Breadmaker", "Kill Switch", "Scrapper", "Buckshot", "Chocolate", "Knuckles", "Shadow Chaser", "Gladiator", "Liquid Science", "Shooter", "Capital F", "Cobra", "Sidewalk Enforcer", "Captain Peroxide", "General", "Skull Crusher", "Boa Lover", "Sky Bully", "Cereal Killer", "Lord Pistachio", "Blackout", "Mad American", "Snake Eyes", "Chocolate Thunder", "Mad Jack","Snow Hound", "Mad Rascal", "Sofa King", "Commando", "Speedwell", "Marbles", "Cosmo", "Married Man", "Springheel Jack", "Crash Override", "Marshmallow", "Crash Test", "Mental", "Stacker of Wheat", "Crazy Eights", "Mercury Reborn", "Sugar Man", "Midas", "Suicide Jockey", "Cross Thread", "Midnight Rambler", "Swampmasher", "Midnight Rider", "Swerve", "Dancing Madman", "Mindless Bobcat", "Mr. 44", "Take Away", "Dark Horse", "Mr. Fabulous", "Tan Stallion", "Day Hawk", "Mr. Gadget", "The China Wall", "Desert Haze", "HMS Uncooked Rise", "Mr. Lucky", "The Dude", "Digger", "Mr. Peppermint", "The Flying Mouse", "Disco Thunder", "Mr. Spy", "The Happy Jock", "Disco Potato", "Mr. Thanksgiving", "Dr. Cocktail", "Mr. Wholesome", "Thrasher", "Dropkick", "Mule Skinner", "Toolmaker", "Drop Stone", "Murmur", "Tough Nut", "Nacho", "Trip", "Easy Sweep", "Natural Mess", "Electric Player", "Necromancer", "Turnip King", "Twitch", "Fast Draw", "Nessie", "Nickname Master", "Vortex", "Freak", "Nightmare King", "Night Train", "Wheels", "Grave Digger", "Guillotine", "Gunhawk", "Zero", "Highlander", "Zod", "Blinker", "RawSkills", "Predator", "Dark Matter", "ThermalMode", "Roadspike", "Kazami of Truth", "Eye Devil", "Stealth", "Apex", "DragonBlood", "DeathDancer", "Sweet Bacon", "Coldy", "Sepukku", "1st Degree Burn", "Ice", "Steel", "Forger", "Kamikaze Grandma", "Infinite Hole", "Vermilion", "BlackExcalibur", "Rocket", "Third Moon", "The Final Judgement", "Trash Master", "Outlaw", "Slicer", "Liquid Death", "FLAK Angel", "Helmet Destroyer", "Leaf Assassin", "Killer Grenade", "Engine Killer" };
    private GameObject enemy;
    private Vector3 boatPosition;
    private float beginAttackSpeed;
    private bool nameSelected;
    public bool shipSunk;
    private bool sinkTimerUp;
    private int damageDone;
    private Money money;
    private RefundManager refund;

    public virtual void Start()
    {
        refund = GameObject.Find("ScriptManager").GetComponent<RefundManager>();

        money = GameObject.Find("ScriptManager").GetComponent<Money>();

        for (int i = 0; i < cannonParent.childCount; i++)
        {
            cannons.Add(cannonParent.GetChild(i));
        }

        beginAttackSpeed = attackSpeed;
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            StartCoroutine(Explode());
        }

        if (shipSunk)
        {
            GetComponent<NavMeshAgent>().enabled = false;
            SinkingShipRotation();
        }

        ShipDestroyed();
        NameSelection();
        DetectedPlayer();

        if (sinkTimerUp)
        {
            boatPosition = transform.position;
            transform.position = new Vector3(transform.position.x, boatPosition.y -= 0.1f, transform.position.z);
        }
    }

    void OnMouseOver()
    {
        nameDisplay.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        nameDisplay.gameObject.SetActive(false);
    }

    public void Shoot()
    {
        attackSpeed -= Time.deltaTime;

        if(attackSpeed <= 0 && enemy != null)
        {
            for (int i = 0; i < cannons.Count; i++)
            {
                Instantiate(shootEffect, cannons[i].position, cannons[i].rotation, GameObject.Find("ParticleParent").transform);
            }

            attackSpeed = beginAttackSpeed;

            damageDone = Random.Range((int)damage.x, (int)damage.y);

            if (enemy.GetComponent<BasePlane>().armor >= 0)
            {
                enemy.GetComponent<BasePlane>().armor -= damageDone;
            }
            else
            {
                enemy.GetComponent<BasePlane>().health -= damageDone;
            }
        }
    }

    public void DetectedPlayer()
    {
        if (gunFov.playerRef != null)
        {
            enemy = gunFov.playerRef;
        }

        if (gunFov.canSeePlayer && gunFov.playerRef != null)
        {
            Shoot();
        }
    }

    public void NameSelection()
    {
        if (!nameSelected)
        {
            shipName = GetRandomName();
        }
        if (gameObject.name != "Temp" && !nameSelected)
        {
            nameText = nameDisplay.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            nameText.text = shipName;

            if (shipName == "Unsinkable")
            {
                Debug.Log("Unsinkable");
            }
        }

        nameSelected = true;

        nameDisplay.transform.rotation = Quaternion.LookRotation(transform.position - GameObject.FindGameObjectWithTag("MainCamera").transform.position);
    }
    public string GetRandomName()
    {
        return names[Random.Range(0, names.Length)];
    }

    private bool tempBool;
    public virtual void ShipDestroyed()
    {
        //sinking
        if (health <= 0)
        {
            GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<WateverVolumeFloater>().enabled = false;

            if(!tempBool)
            {
                tempBool = true;
                money.money += destroyedShipMoney;
            }
        }
    }

    public Transform explosionParent;
    public List<Transform> explosionLocations;
    public GameObject explosion;
    private int loopedTimes;
    public GameObject sinkRotation;
    public virtual IEnumerator Explode()
    {
        shipSunk = true;

        health = 0;

        this.GetComponent<WateverVolumeFloater>().enabled = false;

        for (int i = 0; i < explosionParent.childCount; i++)
        {
            explosionLocations.Add(explosionParent.GetChild(i));
        }

        for (int i = 0; i < explosionLocations.Count; i++)
        {
            loopedTimes++;
            Instantiate(explosion, explosionLocations[i].position, explosionLocations[i].rotation, gameObject.transform);
            if(loopedTimes >= explosionLocations.Count)
            {
                yield return new WaitForSeconds(sinkTime);
                sinkTimerUp = true;
            }
        }
    }

    public void OnMouseDown()
    {
        refund.shipToBlowUp = gameObject.GetComponent<ShipBaseScript>();
    }

    public void SinkingShipRotation()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, sinkRotation.transform.rotation, speed * Time.deltaTime);
    }
}

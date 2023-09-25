using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShipBaseScript : MonoBehaviour
{
    //info
    public string name;
    public string ShipClass;
    public string description;
    public string type;

    //stats
    public float health;
    public Vector2 damage;
    public float attackSpeed;
    public float armor;
    public int speed;

    //Etc
    public int respawnTime;
    private string[] names = new string[] { "3D Waffle", "Unsinkable", "Hightower", "101", "Houston", "GatlingGun", "Accidental Genius", "Prometheus", "Psycho, Pusher", "Junkyard Dog", "Roadblock", "Rooster", "Breadmaker", "Kill Switch", "Scrapper", "Buckshot", "Chocolate", "Knuckles", "Shadow Chaser", "Gladiator", "Liquid Science", "Shooter", "Capital F", "Cobra", "Sidewalk Enforcer", "Captain Peroxide", "General", "Skull Crusher", "Boa Lover", "Sky Bully", "Cereal Killer", "Lord Pistachio", "Blackout", "Mad American", "Snake Eyes", "Chocolate Thunder", "Mad Jack","Snow Hound", "Mad Rascal", "Sofa King", "Commando", "Speedwell", "Marbles", "Cosmo", "Married Man", "Springheel Jack", "Crash Override", "Marshmallow", "Crash Test", "Mental", "Stacker of Wheat", "Crazy Eights", "Mercury Reborn", "Sugar Man", "Midas", "Suicide Jockey", "Cross Thread", "Midnight Rambler", "Swampmasher", "Midnight Rider", "Swerve", "Dancing Madman", "Mindless Bobcat", "Mr. 44", "Take Away", "Dark Horse", "Mr. Fabulous", "Tan Stallion", "Day Hawk", "Mr. Gadget", "The China Wall", "Desert Haze", "HMS Uncooked Rise", "Mr. Lucky", "The Dude", "Digger", "Mr. Peppermint", "The Flying Mouse", "Disco Thunder", "Mr. Spy", "The Happy Jock", "Disco Potato", "Mr. Thanksgiving", "Dr. Cocktail", "Mr. Wholesome", "Thrasher", "Dropkick", "Mule Skinner", "Toolmaker", "Drop Stone", "Murmur", "Tough Nut", "Nacho", "Trip", "Easy Sweep", "Natural Mess", "Electric Player", "Necromancer", "Turnip King", "Twitch", "Fast Draw", "Nessie", "Nickname Master", "Vortex", "Freak", "Nightmare King", "Night Train", "Wheels", "Grave Digger", "Guillotine", "Gunhawk", "Zero", "Highlander", "Zod", "Blinker", "RawSkills", "Predator", "Dark Matter", "ThermalMode", "Roadspike", "Kazami of Truth", "Eye Devil", "Stealth", "Apex", "DragonBlood", "DeathDancer", "Sweet Bacon", "Coldy", "Sepukku", "1st Degree Burn", "Ice", "Steel", "Forger", "Kamikaze Grandma", "Infinite Hole", "Vermilion", "BlackExcalibur", "Rocket", "Third Moon", "The Final Judgement", "Trash Master", "Outlaw", "Slicer", "Liquid Death", "FLAK Angel", "Helmet Destroyer", "Leaf Assassin", "Killer Grenade", "Engine Killer" };
    
    //namedisplay
    public Canvas nameDisplay;
    private TextMeshProUGUI nameText;

    public string GetRandomName()
    {
        return names[Random.Range(0, names.Length)];
    }

    public void Start()
    {
        if(name != "unsinkable")
        {
            name = GetRandomName();
        }

        nameText = nameDisplay.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        nameText.text = name;
    }

    public void Update()
    {
        nameDisplay.transform.rotation = Quaternion.LookRotation(transform.position - GameObject.FindGameObjectWithTag("MainCamera").transform.position);
    }

    void OnMouseOver()
    {
        nameDisplay.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        nameDisplay.gameObject.SetActive(false);
    }
}

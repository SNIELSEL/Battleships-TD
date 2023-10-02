using Bitgem.VFX.StylisedWater;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasePlane : MonoBehaviour
{
    [Header("ShipInfo")]
    public string name;
    public string ShipClass;
    public string description;
    public string type;

    [Header("stats")]
    public float health;
    public Vector2 damage;
    public float attackSpeed;
    public float armor;
    public int speed;

    private float beginAttackSpeed;

    public void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

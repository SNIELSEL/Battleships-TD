using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeBoemBoem : MonoBehaviour
{
    private int dmg;

    public void Start()
    {
        dmg = GetComponent<Kamikaze>().nonRandomDmg;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBase" || collision.gameObject.tag == "EnemyShip")
        {
            collision.gameObject.GetComponent<ShipBaseScript>().health -= dmg;

            GetComponent<BasePlane>().Explode();
        }
    }
}

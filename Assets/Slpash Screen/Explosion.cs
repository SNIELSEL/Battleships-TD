using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class Explosion : MonoBehaviour
{
    public ParticleSystem explosion;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlaneCarrier")
        {
            ParticleSystem.Instantiate(explosion);
        }
    }
}

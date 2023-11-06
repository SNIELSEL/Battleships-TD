using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelorRotation : MonoBehaviour
{
    public float propellorSpeed;
    public float propellorVelocity;
    public float propellorMaxSpeed;
    public Vector3 rotation;

    void Start()
    {
        
    }


    void Update()
    {
        if(propellorSpeed <= propellorMaxSpeed)
        {
            propellorSpeed += propellorVelocity * Time.deltaTime;
            rotation.z = propellorSpeed;

            transform.Rotate(0, 0, rotation.z);
        }
        else
        {
            propellorSpeed = propellorMaxSpeed - 1;
        }
    }
}

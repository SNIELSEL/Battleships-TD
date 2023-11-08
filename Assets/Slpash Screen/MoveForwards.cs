using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwards : MonoBehaviour
{
    public float flightSpeed;
    public Vector3 movement;


    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        movement.z = flightSpeed;

        transform.Translate(movement * Time.deltaTime);
    }
}

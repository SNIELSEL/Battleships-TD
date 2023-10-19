using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoRotation : MonoBehaviour
{
    public Vector2 rotation;

    public Transform ship;

    void Start()
    {
        
    }

    void Update()
    {
        ShipRotation();
    }

    public void ShipRotation()
    {
        rotation.x = Input.GetAxis("Mouse X");
        rotation.y = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(0))
        {
            ship.Rotate(rotation.x, 0, rotation.y);
        }
    }
}

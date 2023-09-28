using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCreddits : MonoBehaviour
{
    public GameObject credits;
    public float scrollSpeed;
    public float yOffset;

    private float yLocation;

    private Vector3 location;
    void Start()
    {
        yLocation = credits.transform.position.y;
        yLocation -= yOffset * 100;
    }

    void Update()
    {
        yLocation += scrollSpeed* Time.deltaTime * 100;

        location = new Vector3(credits.transform.position.x,yLocation, credits.transform.position.z);


        credits.transform.position = location;
    }

    public void ResetCredits()
    {
        yLocation= 0;
        yLocation -= yOffset * 100;
    }
}

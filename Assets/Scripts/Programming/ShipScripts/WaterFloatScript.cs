using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFloatScript : MonoBehaviour
{
    public float floatVelocity;
    public float floatSpeed;
    public float minlocation;
    public float currentLocation;
    public float maxLocation;

    private bool firstSycleFinished;
    private bool goingUp;
    private bool goingDown;

    private float lastLocation;
    private int upOrDown;
    public void Start()
    {
        StartCoroutine(CheckForInacuracy());

        minlocation = minlocation += transform.position.y;
        maxLocation = maxLocation += transform.position.y;

        upOrDown = Random.Range(0, 2);
    }
    void Update()
    {
        if (!firstSycleFinished)
        {
            FirstCycle();
        }

        if (currentLocation <= minlocation && firstSycleFinished)
        {
            goingUp = true;
            goingDown = false;
            currentLocation += floatVelocity * Time.deltaTime;
        }

        if (currentLocation >= maxLocation && firstSycleFinished)
        {
            goingDown = true;
            goingUp = false;
            currentLocation -= floatVelocity * Time.deltaTime;
        }

        if (goingUp)
        {
            currentLocation += floatVelocity * Time.deltaTime;
            transform.position += new Vector3(0,floatVelocity,0) * floatSpeed * Time.deltaTime;
        }
        else if (goingDown)
        {
            currentLocation -= floatVelocity * Time.deltaTime;
            transform.position -= new Vector3(0, floatVelocity, 0) * floatSpeed * Time.deltaTime;
        }
    }

    public void FirstCycle()
    {
        if (currentLocation <= maxLocation && currentLocation >= minlocation && !firstSycleFinished)
        {

            if(upOrDown == 0)
            {
                goingDown = true;
            }
            else if(upOrDown >= 1)
            {
                goingDown = true;
            }
        }

        if (currentLocation <= minlocation && !firstSycleFinished)
        {
            firstSycleFinished = true;
            goingUp = true;
        }

        if (currentLocation >= maxLocation && !firstSycleFinished)
        {
            firstSycleFinished = true;
            goingDown=true;
        }
    }

    public IEnumerator CheckForInacuracy()
    {
        lastLocation = currentLocation;

        yield return new WaitForSeconds(2);
        
        if(currentLocation == lastLocation)
        {
            currentLocation += floatVelocity;
        }

        StartCoroutine(CheckForInacuracy());
    }
}

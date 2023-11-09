using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInstantiator : MonoBehaviour
{
    public GameObject camera;

    void Start()
    {
        Instantiate(camera);
    }
}

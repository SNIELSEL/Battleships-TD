using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject camera;
    public GameObject cameraPosition;

    public Vector3 startcameraPos;

    private bool startFollow;

    public void Start()
    {
        StartCoroutine(StartFollowing());
    }

    public IEnumerator StartFollowing()
    {
        yield return new WaitForSeconds(0.2f);

        camera = GameObject.FindGameObjectWithTag("BoemCamera");

        startcameraPos = camera.transform.position;

        startFollow = true;
    }
    private void Update()
    {
        if (startFollow)
        {
            camera.transform.position = cameraPosition.transform.position;
            camera.transform.rotation = cameraPosition.transform.rotation;
        }
    }
}

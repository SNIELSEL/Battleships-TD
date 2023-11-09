using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCrashCheck : MonoBehaviour
{

    public GameObject kamikazePlane;
    public Camera mainCamera;

    private bool planeCrashed;

    public GameObject[] planes;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();

        planes = GameObject.FindGameObjectsWithTag("Target");

        for (int i = 0; i < planes.Length; i++)
        {
            if (planes[i].GetComponent<Kamikaze>() != null)
            {
                kamikazePlane = planes[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(kamikazePlane == null)
        {
            StartCoroutine(DeleteCamera());
        }
    }

    public IEnumerator DeleteCamera()
    {
        if (!planeCrashed)
        {
            planeCrashed = true;

            yield return new WaitForSeconds(2);

            mainCamera.enabled = true;
            Destroy(gameObject);
        }
    }
}

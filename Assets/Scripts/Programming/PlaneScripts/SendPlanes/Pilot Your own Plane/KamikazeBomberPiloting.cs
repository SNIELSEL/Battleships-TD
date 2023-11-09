using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class KamikazeBomberPiloting : MonoBehaviour
{
    public float flightSpeed, speedCap, startSpeed, flightRotation, cameraSmooth, sens, camSwayHor, camSwayVer, angleCount;
    public Vector3 movement, rotation;
    public Transform tPPCamera;
    private quaternion target;
    private Rigidbody rb;

    public Vector3 rotateAngle;

    Vector3 angleV3;

    void Start()
    {
        flightSpeed = startSpeed;

        target = tPPCamera.transform.localRotation;
        rb = GetComponent<Rigidbody>();

        MouseLock();
    }

    void Update()
    {
        Movement();
        Rotation();
    }

    public void MouseLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Movement()
    {
        movement.z = flightSpeed;
        transform.Translate(movement * Time.deltaTime);

        float angle = Input.GetAxis("Horizontal");
        angleV3.z = angle * -angleCount;
        angleV3.y = angle * -angleCount;

        if (Input.GetKey(KeyCode.S))
        {
            angleV3.x = -angleCount;
        }

        if (Input.GetKey(KeyCode.W))
        {
            angleV3.x = angleCount;
        }

        transform.Rotate(angleV3 * Time.deltaTime);
        angleV3.x = 0;
    }

    public void Rotation()
    {
        rotation.y = Input.GetAxis("Mouse X");
        rotation.x = Input.GetAxis("Mouse Y");

        transform.Rotate(rotation * Time.deltaTime * sens);

        rotateAngle.z = rotation.z * Time.deltaTime;

        Quaternion rotationX = Quaternion.AngleAxis(-rotation.z * camSwayHor, Vector3.right * Time.deltaTime);
        Quaternion rotationY = Quaternion.AngleAxis(rotation.x * camSwayVer, Vector3.up * Time.deltaTime);

        Quaternion target = rotationX * rotationY;

        tPPCamera.localRotation = Quaternion.Slerp(tPPCamera.localRotation, target, cameraSmooth * Time.deltaTime);

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class KamikazeBomberPiloting : MonoBehaviour
{
    public float flightSpeed, speedCap, startSpeed, flightRotation, cameraSmooth, sens, camSwayHor, camSwayVer;
    public Vector3 movement, rotation;
    public Transform tPPCamera;
    private quaternion target;
    private Rigidbody rb;

    public Vector2 rotateAngle;

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
        movement.z = Input.GetAxis("Horizontal");

        movement.z = flightSpeed;

        transform.Translate(movement * Time.deltaTime);
    }

    public void Rotation()
    {
        rotation.y = Input.GetAxis("Mouse X");
        rotation.x = Input.GetAxis("Mouse Y");

        transform.Rotate(rotation * Time.deltaTime * sens);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateAngle.x, 0);
            transform.Rotate(0, 0, -rotateAngle.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateAngle.x, 0);
            transform.Rotate(0, 0, rotateAngle.y);
        }

        Quaternion rotationX = Quaternion.AngleAxis(-rotation.z * camSwayHor, Vector3.right * Time.deltaTime);
        Quaternion rotationY = Quaternion.AngleAxis(rotation.x * camSwayVer, Vector3.up * Time.deltaTime);

        Quaternion target = rotationX * rotationY;

        tPPCamera.localRotation = Quaternion.Slerp(tPPCamera.localRotation, target, cameraSmooth * Time.deltaTime);

    }
}

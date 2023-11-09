using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera enemyCamera;
    public Camera kamikazeCamera;
    public Button backButton;
    public GameObject planeUI;

    public void CameraSwitcher()
    {
        if(mainCamera.enabled == true)
        {
            mainCamera.enabled = false;
            enemyCamera.enabled = true;
        }
        else
        {
            mainCamera.enabled = true;
            enemyCamera.enabled = false;
        }
    }

    public void BackToMainCamera()
    {
        mainCamera.enabled = true;
        enemyCamera.enabled = false;
    }

    public void KamikazeCamera()
    {
        planeUI.SetActive(false);
        kamikazeCamera = GameObject.FindGameObjectWithTag("BoemCamera").GetComponent<Camera>();
        mainCamera.enabled = false;
        enemyCamera.enabled = false;
        kamikazeCamera.enabled = true;
    }
}

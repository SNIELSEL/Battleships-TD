using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawnCanvasCancel : MonoBehaviour
{
    public Canvas mainCanvas, planeCanvas;

    public void onButtonClick()
    {
        mainCanvas.gameObject.SetActive(true);
        planeCanvas.gameObject.SetActive(false);
    }
}

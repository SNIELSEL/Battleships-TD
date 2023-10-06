using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawnCanvasCancel : MonoBehaviour
{
    public Canvas mainCanvas, planeCanvas;

    public void onButtonClick()
    {
        mainCanvas.enabled= true;
        planeCanvas.enabled= false;
    }
}

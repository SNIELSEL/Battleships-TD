using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnShipClick : MonoBehaviour
{
    public Canvas mainCanvas, planeSpawnCanvas;
    public void OnClick(BaseEventData data)
    {
        PointerEventData pData = (PointerEventData)data;
        Debug.Log("Working");
    }

    void OnMouseDown()
    {
        mainCanvas.enabled= false;
        planeSpawnCanvas.enabled = true;
    }
}

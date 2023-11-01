using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnOFF : MonoBehaviour
{
    public void ToggleUI(GameObject ui)
    {
        ui.SetActive(!ui.activeSelf);
    }
}

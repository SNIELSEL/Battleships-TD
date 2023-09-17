using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject[] ships;
    public Transform[] spawnLocations;

    private int[] shipLocationArrayInt;
    private int[] shipArrayInt;

    [System.Serializable]
    private struct VariableGroup
    {
        public GameObject[] shipsBottomLeft;
        public GameObject[] shipsBottomRight;
        public GameObject[] shipsMiddle;
        public GameObject[] shipsTopLeft;
        public GameObject[] shipsTopRight;
        public VariableGroup(GameObject[] ships_BL, GameObject[] ships_BR, GameObject[] ships_M, GameObject[] ships_TL, GameObject[] ships_TR)
        {
            shipsBottomLeft = ships_BL;
            shipsBottomRight = ships_BR;
            shipsMiddle = ships_M;
            shipsTopLeft = ships_TL;
            shipsTopRight = ships_TR;
        } 
    }

    [SerializeField] private VariableGroup m_Variables = new VariableGroup();
}

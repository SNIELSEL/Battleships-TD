using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CredditsBackButton : MonoBehaviour
{
    public GameObject button, creddits;

    void Start()
    {
        button.SetActive(false);
    }


    void Update()
    {
        ShowButton();
    }

    public void ShowButton()
    {
        if (creddits.activeInHierarchy)
        {
            StartCoroutine(SetButtonActive());
        }
    }

    public IEnumerator SetButtonActive()
    {
        yield return new WaitForSeconds(0.15f);
        button.SetActive(true);
    }
}

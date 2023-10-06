using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDeleter : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(DeleteEffect());
    }

    public IEnumerator DeleteEffect()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}

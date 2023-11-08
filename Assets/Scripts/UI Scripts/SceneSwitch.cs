using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public float seconds = 10f;

    public void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(SwitchToMain(1));
        }
    }
    public void ToSwitch(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public IEnumerator SwitchToMain(int sceneToLoad)
    {
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(sceneToLoad);
    }
}

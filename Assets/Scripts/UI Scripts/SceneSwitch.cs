using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void OnClick(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

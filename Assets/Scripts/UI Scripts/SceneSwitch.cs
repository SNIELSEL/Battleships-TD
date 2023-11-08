using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public float seconds = 10f;
    public Slider progressSlider;
    public GameObject loadingScreen;
    public GameObject menu;

    public void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(SwitchToMain(1));
        }

        loadingScreen.SetActive(false);
    }
    public void ToSwitch(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Loadscreen(int sceneToLoad)
    {
        StartCoroutine(LoadSceneAsync(sceneToLoad));
    }

    public IEnumerator SwitchToMain(int sceneToLoad)
    {
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator LoadSceneAsync(int levelInt)
    {
        menu.SetActive(false);
        loadingScreen.SetActive(true);

        AsyncOperation op = SceneManager.LoadSceneAsync(levelInt);

        op.allowSceneActivation = false;

        yield return new WaitForSeconds(5);

        op.allowSceneActivation = true;

        while (!op.isDone)
        {
            int numOfRoundedDecimals = 1;
            float progress = Mathf.Clamp01(op.progress / .9f);
            progress = Mathf.Round(progress * Mathf.Pow(10, numOfRoundedDecimals)) / Mathf.Pow(10, numOfRoundedDecimals);
            progressSlider.value = progress;
            yield return null;
        }
    }
}

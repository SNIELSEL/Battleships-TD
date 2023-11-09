using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public float seconds = 10f;
    public float loadSpeed;
    public Slider progressSlider;
    public GameObject loadingScreen;
    public GameObject menu;
    public float smoothLoadProgress;
    private AsyncOperation operation;
    private bool doneWithSmoothLoad;
    private bool begunLoading;
    private bool inMain; 

    public void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(SwitchToMain(1));
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            inMain = true;
        }

        if (!inMain)
        {
            loadingScreen.SetActive(false);
        }
    }

    private void Update()
    {
        if (!inMain)
        {
            if (!doneWithSmoothLoad && begunLoading)
            {
                progressSlider.value = smoothLoadProgress;
                smoothLoadProgress += loadSpeed * Time.deltaTime;
            }

            if (progressSlider.value >= 1)
            {
                doneWithSmoothLoad = true;
            }

            if (doneWithSmoothLoad)
            {
                operation.allowSceneActivation = true;
            }
        }
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
        begunLoading = true;
        menu.SetActive(false);
        loadingScreen.SetActive(true);

        operation = SceneManager.LoadSceneAsync(levelInt);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            int numOfRoundedDecimals = 1;
            float progress = Mathf.Clamp01(operation.progress / .9f);
            progress = Mathf.Round(progress * Mathf.Pow(10, numOfRoundedDecimals)) / Mathf.Pow(10, numOfRoundedDecimals);
            yield return null;
        }
    }
}

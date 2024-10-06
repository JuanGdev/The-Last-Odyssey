using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject LoadingScreen;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
            // Load the first level of the game based on SceneIndexes.cs order and build settings
            SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_SCENE, LoadSceneMode.Additive);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    
    
    public void LoadGame(SceneIndexes sceneIndex)
    {
        StartCoroutine(LoadGameWithFakeLoading(sceneIndex));
    }

    private IEnumerator LoadGameWithFakeLoading(SceneIndexes sceneIndex)
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_SELECTOR));
        LoadingScreen.gameObject.SetActive(true);

        Debug.Log("Activating the loading screen");

        yield return StartCoroutine(FakeLoadingScreen());

        SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_1, LoadSceneMode.Additive);
        StartCoroutine(GetSceneLoadProgress());
    }

    private IEnumerator FakeLoadingScreen()
    {
        float fakeProgress = 0f;
        while (fakeProgress < 1f)
        {
            float increment = UnityEngine.Random.Range(0.1f, 0.2f); // Random increment between 0.1 and 0.2
            fakeProgress += increment;
            yield return new WaitForSeconds(0.5f); // Simulate loading time
            // Simulate other events here
            Debug.Log("Simulating event during fake loading: " + (fakeProgress * 100) + "%");
        } 
    }

    public IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return new WaitForSeconds(0.1f); // Add a delay to slow down the progress bar update
            }
        }
        LoadingScreen.gameObject.SetActive(false);
    }
}
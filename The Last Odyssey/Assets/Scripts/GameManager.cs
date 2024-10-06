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
    public bool[] exoplanetsLocked = new bool[3];
    public string[] exoplanetMessages = new string[3];
    
    void Awake()
    {
        // Initialize the exoplanetsLocked array
        exoplanetsLocked[0] = true;
        exoplanetsLocked[1] = false;
        exoplanetsLocked[2] = false;
        
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
    
    public void LoadGame(SceneIndexes sceneIndex)
    {
        StartCoroutine(LoadGameWithFakeLoading(sceneIndex));
    }

    private IEnumerator LoadGameWithFakeLoading(SceneIndexes sceneIndex)
    {
        SceneManager.UnloadSceneAsync((int)SceneIndexes.CINEMATIC_SCENE);
        LoadingScreen.gameObject.SetActive(true);

        Debug.Log("Activating the loading screen");

        yield return StartCoroutine(FakeLoadingScreen());
        LoadingScreen.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_SELECTOR, LoadSceneMode.Additive);
    }

    private IEnumerator FakeLoadingScreen()
    {
            yield return new WaitForSeconds(13f); // Simulate loading time
    }
}
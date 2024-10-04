using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_1, LoadSceneMode.Additive);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public void LoadGame()
    {
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_1));
        LoadingScreen.gameObject.SetActive(true);
        Debug.Log("Activating the loadging screen");
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_2, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }
    public IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                Debug.Log("Loading progress: " + scenesLoading[i].progress);
                yield return null;
            }
        }
        LoadingScreen.gameObject.SetActive(false);
    }
}
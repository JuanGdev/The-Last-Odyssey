using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public void Awake()
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_1, LoadSceneMode.Additive);
    }

    public void LoadGame()
    {
        SceneManager.UnloadSceneAsync((int)SceneIndexes.LEVEL_1);
        SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_2, LoadSceneMode.Additive);
    }
}

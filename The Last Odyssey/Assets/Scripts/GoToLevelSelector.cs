using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneTransition : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public SceneIndexes nextScene;

    void Start()
    {
        // Add listener for when the video finishes playing
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Start coroutine to transition to the next scene
        StartCoroutine(TransitionToNextScene());
    }

    private IEnumerator TransitionToNextScene()
    {
        // Optionally, add a delay here if needed
        yield return new WaitForSeconds(13.0f);
        
        // Unload the current scene
        SceneManager.UnloadSceneAsync((int)SceneIndexes.CINEMATIC_SCENE);
        // Load the next scene
        GameManager.instance.LoadGame(nextScene);
    }
}
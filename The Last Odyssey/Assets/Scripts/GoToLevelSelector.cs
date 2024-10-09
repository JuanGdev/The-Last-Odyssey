using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class VideoSceneTransition : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    
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
        yield return new WaitForSeconds(3.0f);
        
        // Unload the current scene
        SceneManager.UnloadSceneAsync("CinematicScene");
        // Load the next scene
        SceneManager.LoadScene("LevelSelector");
    }
}
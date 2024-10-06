using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLevel : MonoBehaviour
{
    public Animator KeyPressedPanel;

    void Update()
    {
        // When any key is pressed, load the next scene
        if (Input.anyKeyDown && !KeyPressedPanel.GetBool("KeyPressed"))
        {
            // Change the value of the animator parameter KeyPressed to true
            KeyPressedPanel.SetBool("KeyPressed", true);

            // Start coroutine to unload the current scene after a delay
            StartCoroutine(UnloadCurrentSceneWithDelay());

            // Load the next scene
            //SceneManager.LoadSceneAsync((int)SceneIndexes.CINEMATIC_SCENE, LoadSceneMode.Additive);
        }
    }

    private IEnumerator UnloadCurrentSceneWithDelay()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1.5f);
        SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_SCENE);
        SceneManager.LoadSceneAsync((int)SceneIndexes.CINEMATIC_SCENE, LoadSceneMode.Additive);
    }
}
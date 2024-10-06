    using System;
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLevel : MonoBehaviour
{
    public GameObject animationActivate;
    public Animator KeyPressedPanel;
    private bool delayApplied = false;
    
    void Start()
    {
        // Inicia la corrutina con el delay
        StartCoroutine(EnableComponent(10f));  
    }
    void Update()
    {
        // When any key is pressed, load the next scene
        if (Input.anyKeyDown && !KeyPressedPanel.GetBool("KeyPressed") && delayApplied)
        {
            // Change the value of the animator parameter KeyPressed to true
            KeyPressedPanel.SetBool("KeyPressed", true);
            
            // Start coroutine to unload the current scene after a delay
            StartCoroutine(UnloadCurrentSceneWithDelay());

            // Load the next scene
            SceneManager.LoadSceneAsync((int)SceneIndexes.CINEMATIC_SCENE, LoadSceneMode.Additive);
        }
    }
    
    private IEnumerator EnableComponent(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        // Reproduce la animación
        animationActivate.SetActive(true);
        delayApplied = true;
    }

    private IEnumerator UnloadCurrentSceneWithDelay()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1.5f);
        SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_SCENE);
        SceneManager.LoadSceneAsync((int)SceneIndexes.CINEMATIC_SCENE, LoadSceneMode.Additive);
    }
}
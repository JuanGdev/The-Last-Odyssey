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
            
            // Unload the current scene
            SceneManager.UnloadSceneAsync("MainScene");
            
            // Load the next scene
            SceneManager.LoadScene("CinematicScene");
        }
    }
    
    private IEnumerator EnableComponent(float delay)
    {
        // Wait for the delay
        yield return new WaitForSeconds(delay);
        delayApplied = true;
        // Activate the animation
        animationActivate.SetActive(true);
    }
    
}
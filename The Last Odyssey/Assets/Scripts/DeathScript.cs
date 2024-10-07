using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    bool onDeath = false;
    public static event Action OnDeath;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) ReloadScene();
    }

    void ReloadScene()
    {
        if (onDeath) return; 
        onDeath = true;
        OnDeath();
    }
}

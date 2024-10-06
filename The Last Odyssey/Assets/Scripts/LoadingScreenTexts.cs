// LoadingScreenTexts.cs

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LoadingScreenTexts : MonoBehaviour
{
    public TextMeshProUGUI loadingTextField;
    public int randomIndex;
    private void Start()
    {
        randomIndex = Random.Range(0, 3);
    }

    // Start is called before the first frame update
    void Update()
    {
        loadingTextField.text = GameManager.instance.exoplanetMessages[randomIndex];
    }
}
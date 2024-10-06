// LoadingScreenTexts.cs
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LoadingScreenTexts : MonoBehaviour
{
    public TextMeshProUGUI loadingTextField;

    // Start is called before the first frame update
    void Start()
    {
        loadingTextField.text = GameManager.instance.exoplanetMessages[Random.Range(0, 3)];
        Debug.Log(GameManager.instance.exoplanetMessages[Random.Range(0, 3)]);
    }
}
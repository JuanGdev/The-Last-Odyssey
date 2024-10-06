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
    public string[] loadingTexts = new string[3];
    public TextMeshProUGUI loadingTextField;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize with default messages
        SetLoadingTexts(new string[]
        {
            "Las supertierras están compuestas de gas, roca o una mezcla de ambos",
            "Las supertierras son entre dos veces más grandes que la Tierra y hasta diez veces más masivas",
            "El nombre supertierra se refiere solo a su tamaño, pues no son parecidas a nuestro planeta"
        });
    }

    // Method to set loading texts based on selected exoplanet
    public void SetLoadingTexts(string[] messages)
    {
        loadingTexts = messages;
        loadingTextField.text = loadingTexts[Random.Range(0, loadingTexts.Length)];
    }
}
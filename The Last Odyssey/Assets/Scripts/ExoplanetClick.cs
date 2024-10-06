// ExoplanetClick.cs
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ExoplanetClick : MonoBehaviour
{
    private GameObject currentCard; 
    public GameObject exoplanetMain;
    public GameObject exoplanetAnother1;
    public GameObject exoplanetAnother2;
    public GameObject exoplanetLocked;
    public int exoplanetIndex;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    if (GameManager.instance.exoplanetsLocked[exoplanetIndex])
                    {
                        exoplanetMain.SetActive(true);
                        exoplanetLocked.SetActive(false);
                        exoplanetAnother1.SetActive(false);
                        exoplanetAnother2.SetActive(false);
                    }
                    else
                    {
                        exoplanetMain.SetActive(false);
                        exoplanetLocked.SetActive(true);
                        exoplanetAnother1.SetActive(false);
                        exoplanetAnother2.SetActive(false);
                    }

                    // Update loading texts based on selected exoplanet
                    string[] messages = GetMessagesForExoplanet(exoplanetIndex);
                    // Load the messages to the exoplanetsMessages array in GameManager
                    GameManager.instance.exoplanetMessages = messages;
                }
            }
        }
    }

    // Method to get messages for a specific exoplanet
    private string[] GetMessagesForExoplanet(int index)
    {
        switch (index)
        {
            case 0:
                return new string[]
                {
                    "Mensaje 1 para exoplaneta 0",
                    "Mensaje 2 para exoplaneta 0",
                    "Mensaje 3 para exoplaneta 0"
                };
            case 1:
                return new string[]
                {
                    "Mensaje 1 para exoplaneta 1",
                    "Mensaje 2 para exoplaneta 1",
                    "Mensaje 3 para exoplaneta 1"
                };
            case 2:
                return new string[]
                {
                    "Mensaje 1 para exoplaneta 2",
                    "Mensaje 2 para exoplaneta 2",
                    "Mensaje 3 para exoplaneta 2"
                };
            default:
                return new string[]
                {
                    "Mensaje por defecto 1",
                    "Mensaje por defecto 2",
                    "Mensaje por defecto 3"
                };
        }
    }
}
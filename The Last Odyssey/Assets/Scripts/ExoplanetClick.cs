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
                }
            }
        }
    }
    
}
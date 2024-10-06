using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExoplanetClick : MonoBehaviour
{
    private GameObject currentCard;
    public string SceneName;
    public GameObject exoplanetCard;
    public Button skipButton;

    public GameObject exoplanetCardB;
    public GameObject exoplanetCardC;

    void Start()
    {
        // Add listener to the button's onClick event
        skipButton.onClick.AddListener(OnButtonClick);
    }

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
                    exoplanetCard.SetActive(true);
                }
            }
        }
    }

    private IEnumerator LoadSceneWithLoadingUI()
    {
        // Load the LoadingUI scene
        SceneManager.LoadScene("LoadingUIScene", LoadSceneMode.Additive);
        // Wait for 8 seconds
        yield return new WaitForSeconds(8f);
        // Unload the LoadingUI scene
        currentCard.SetActive(false);    
    }

    void OnButtonClick()
    {
        // Add your button click handling logic here
        SceneManager.LoadScene(SceneName);
        
    }
}
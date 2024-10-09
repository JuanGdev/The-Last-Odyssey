using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExoplanetClick : MonoBehaviour
{
    public GameObject currentCard;
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
                    exoplanetCard.GetComponent<Animator>().SetBool("Locked", false);
                    exoplanetCardB.GetComponent<Animator>().SetBool("Locked", true);
                    exoplanetCardC.GetComponent<Animator>().SetBool("Locked", true);
                }
            }
        }
    }

    private IEnumerator LoadSceneWithLoadingUI()
    {
        currentCard.SetActive(false);
        // Load the LoadingUI scene
        SceneManager.LoadScene("LoadingUIScene", LoadSceneMode.Additive);
        // Wait for 8 seconds
        yield return new WaitForSeconds(8f);
        // Unload the LoadingUI scene
        SceneManager.UnloadSceneAsync("LoadingUIScene");
    }

    void OnButtonClick()
    {
        StartCoroutine(LoadSceneWithLoadingUI());
        // Add your button click handling logic here
        SceneManager.LoadScene(SceneName);
        
    }
}
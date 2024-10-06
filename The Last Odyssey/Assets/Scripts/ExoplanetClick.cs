using UnityEngine;
using UnityEngine.UI;

public class ExoplanetClick : MonoBehaviour
{
    public GameObject uiCardPrefab; // Prefab de la tarjeta UI
    public Transform uiPosition; // Posición donde aparecerá la tarjeta (cerca del planeta)
    public string levelName; // Nombre del nivel
    public string levelDescription; // Descripción del nivel

    private GameObject currentCard;
    public int intSceneIndex;

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
                    ShowUICard();
                }
            }
        }
    }

    void ShowUICard()
    {
        // Si ya hay una tarjeta desplegada, destrúyela
        if (currentCard != null)
        {
            Destroy(currentCard);
        }

        // Instanciar la tarjeta UI en la escena
        currentCard = Instantiate(uiCardPrefab, uiPosition.position, Quaternion.identity, uiPosition);

        // Asignar la función al botón
        Button loadButton = currentCard.GetComponentInChildren<Button>();
        loadButton.onClick.AddListener(() => GameManager.instance.LoadGame((SceneIndexes)intSceneIndex));    
    }
}
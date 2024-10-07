using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDeath : MonoBehaviour
{
    [SerializeField] Material starPlayerMaterial;
    [SerializeField] Material material;
    [SerializeField] Transform endPoint;
    [ColorUsage(false, true)]
    [SerializeField] Color32 targetEmissionColor;

    [SerializeField] Color targetColor;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Renderer playerRenderer = GameObject.FindGameObjectWithTag("PlayerMaterial").GetComponent<Renderer>();
        StartCoroutine(ChangeColorMaterial());
        material.SetColor("_EmissionColor", starPlayerMaterial.GetColor(("_EmissionColor")));

        material.color = starPlayerMaterial.color;
        playerRenderer.material = material;
    }

    IEnumerator ChangeColorMaterial()
    {
        yield return null;
        Color startColor = material.color;
        Color32 startEmissionColor = material.GetColor("_EmissionColor");
        float totalDistance = Vector3.Distance(player.transform.position, endPoint.position);

        while (true)
        {
            float currentDistance = Vector3.Distance(player.transform.position, endPoint.position);
            if(currentDistance < 1)
            {
                break;
            }
            float normalized = (totalDistance - currentDistance) / totalDistance;
            Color32 emissionColor = Color32.Lerp(startEmissionColor, targetEmissionColor, normalized);
            Color color = Color.Lerp(startColor, targetColor, normalized);
            
            if (normalized > 0.5)
            {
                GameObject particleSystemObject = player.GetComponentInChildren<ParticleSystem>().gameObject;
                if (particleSystemObject != null) 
                    Destroy(particleSystemObject);
            }
            material.SetColor("_EmissionColor", emissionColor);
            material.color = color;
            yield return null;
        }
    }
}

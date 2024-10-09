using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitSpeed : MonoBehaviour
{
    public Transform star;
    public float orbitSpeedValue = 4.0f;
    public float angle;
    public float orbitRadius = 10.0f;
    
    void Update()
    {
        RepositionPlanet(orbitRadius, angle, orbitSpeedValue);
    }

    void RepositionPlanet(float orbitRadius, float angle, float orbitSpeedValue)
    {
        // Movimiento elíptico en torno a la estrella
        float x = Mathf.Cos(Time.time * orbitSpeedValue + angle * Mathf.Deg2Rad) * orbitRadius;
        float z = Mathf.Sin(Time.time * orbitSpeedValue + angle * Mathf.Deg2Rad) * (orbitRadius + 5);
        transform.position = new Vector3(x, 0, z) + star.position * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying) return;
        RepositionPlanet(orbitRadius, angle, 0);
    }
}

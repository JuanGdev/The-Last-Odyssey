using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitSpeed : MonoBehaviour
{
    public Transform star;
    public float orbitSpeedValue = 10.0f;
    public float orbitRadius = 10.0f;
    
    void Update()
    {
        // Movimiento elíptico en torno a la estrella
        float x = Mathf.Cos(Time.time * orbitSpeedValue) * orbitRadius;
        float z = Mathf.Sin(Time.time * orbitSpeedValue) * (orbitRadius+5);
        transform.position = new Vector3(x, 0, z) + star.position * Time.deltaTime;
    }
}

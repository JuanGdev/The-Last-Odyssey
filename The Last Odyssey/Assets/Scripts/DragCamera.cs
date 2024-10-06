// SolarSystemCameraController.cs
using UnityEngine;

public class SolarSystemCameraController : MonoBehaviour
{
    public Transform target; // The target to orbit around
    public float distance = 10.0f; // Distance from the target
    public float xSpeed = 120.0f; // Speed of rotation around the x-axis
    public float ySpeed = 120.0f; // Speed of rotation around the y-axis

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
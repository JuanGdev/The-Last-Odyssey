// SolarSystemCameraController.cs
using System.Net.Security;
using UnityEngine;

public class SolarSystemCameraController : MonoBehaviour
{
    public Transform target; // The target to orbit around
    public float distance = 100.0f; // Distance from the target
    public float xSpeed = 70.0f; // Speed of rotation around the x-axis
    public float ySpeed = 70.0f; // Speed of rotation around the y-axis
    public float zoomSpeed = 1.0f; // Speed of zooming in and out

    [SerializeField] float horizontalAngle = 0;
    [SerializeField] float verticalAngle = 0;
    float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = verticalAngle;
        y = horizontalAngle;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
        }

        // Handle zooming
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, 2.0f, 100.0f); // Increase the upper limit to allow more zoom out

        RepositionCamera(y, x);
    }

    void RepositionCamera(float horizontalAngle, float verticalAngle)
    {
        Quaternion rotation = Quaternion.Euler(horizontalAngle, verticalAngle, 0);
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying) return;
        RepositionCamera(horizontalAngle, verticalAngle);
    }
}
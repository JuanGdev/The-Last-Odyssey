using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FollowWaypoint : MonoBehaviour
{
    [SerializeField] float speed = 5;
    List<Transform> waypoints;
    Vector3 startPoint;
    int currentWaypoint;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = new(GetComponentsInChildren<Transform>());
        rb = GetComponent<Rigidbody>();
        startPoint = transform.position;
        currentWaypoint = 0;

        foreach (Transform t in waypoints) t.parent = null;

        StartCoroutine(FollowPoint());
    }
    
    IEnumerator FollowPoint()
    {
        while (true)
        {
            if (currentWaypoint == waypoints.Count)
            {
                transform.position = startPoint;
                currentWaypoint = 0;
            }
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = waypoints[currentWaypoint].position;
            float ratio = 0;
            while (true)
            {
                float distance = Vector3.Distance(transform.position, targetPosition);
                if (distance < 0.1f)
                {
                    currentWaypoint++;
                    break;
                }
                float standardSpeed = speed / Vector3.Distance(currentPosition, targetPosition);
                ratio += Time.deltaTime * standardSpeed;
                Vector3 newPosition = Vector3.Lerp(currentPosition, targetPosition, ratio);
                rb.MovePosition(newPosition);
                yield return null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Transform[] waypoints = GetComponentsInChildren<Transform>();
        Gizmos.color = Color.green;
        for (int i = 0; i < waypoints.Length; i++)
            if (i < waypoints.Length - 1) Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
    }
}

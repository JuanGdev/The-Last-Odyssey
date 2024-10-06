using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float speed = 10;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float angle = Mathf.LerpAngle(transform.eulerAngles.x, speed * Time.deltaTime, speed);
        Vector3 eulerAngles = new(angle, transform.eulerAngles.y, transform.eulerAngles.z);
        Quaternion rotation = Quaternion.Euler(eulerAngles);
        rb.MoveRotation(rotation);
    }
}

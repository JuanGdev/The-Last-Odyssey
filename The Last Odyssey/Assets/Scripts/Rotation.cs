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
        Quaternion deltaRotation = Quaternion.Euler(speed * Time.fixedDeltaTime, 0f, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPlayerVelocity : MonoBehaviour
{
    private Rigidbody rb;

    CharacterController characterController;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            characterController = other.GetComponent<CharacterController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            characterController.Move(rb.velocity * Time.deltaTime);
    }

}

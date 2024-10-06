using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float rotationSpeed = 5;
    [SerializeField] float jumpForce = 200;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] CharacterController characterController;
    Trigger groundDetector;
    public bool jumping = false;
    float jumpTime = 0.5f;
    float jumpStartTime = 0;

    public static event Action OnPlayerGrounded;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        groundDetector = transform.GetComponentInChildren<Trigger>();
    }

    private void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        Vector3 inputDirection = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Quaternion camRotation = Quaternion.Euler(new(0, Camera.main.transform.eulerAngles.y, 0));

        Vector3 direction = camRotation * inputDirection;
        fallVector += GravityVector();
        if (groundDetector.triggered && !jumping) fallVector = 2 * Vector3.down;
        characterController.Move(speed * Time.deltaTime * direction + fallVector);
        Rotation(inputDirection);
    }

    void Rotation(Vector3 inputDirection)
    {
        if (inputDirection.magnitude < 0.01) return;
        float angle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(new(0, angle, 0));
        Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = rotation;
    }

    Vector3 fallVector = Vector3.zero;
    void Jump()
    {
        if (!groundDetector.triggered) return;
        if (!jumping) fallVector = Vector3.zero;
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpTime < Time.time - jumpStartTime) jumping = false;
            return;
        }

        jumpStartTime = Time.time;
        fallVector = jumpForce * Time.fixedDeltaTime * Time.fixedDeltaTime * Vector3.up;
        jumping = true;
    }

    float fallVelocity = 0;
    Vector3 GravityVector()
    {
        if (groundDetector.triggered)
        {
            OnPlayerGrounded();
            fallVelocity = 0;
            return Vector3.down * fallVelocity;
        }
        fallVelocity += gravity * Time.deltaTime;
        return fallVelocity * Time.deltaTime * Time.fixedDeltaTime * Vector3.down;
    }
}
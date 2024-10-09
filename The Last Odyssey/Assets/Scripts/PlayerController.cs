using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float jumpForce = 10f; // Adjusted for more reasonable jump height.
    [SerializeField] float gravity = 15f;
    [SerializeField] CharacterController characterController;
    Trigger groundDetector;
    public bool jumping = false;
    public Vector3 inputDirection;
    float jumpTime = 0.5f;
    float jumpStartTime = 0;

    public static event Action OnPlayerGrounded;

    private Vector3 fallVelocity = Vector3.zero;

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
        inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Quaternion camRotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        Vector3 direction = camRotation * inputDirection;

        if (!groundDetector.triggered)
        {
            fallVelocity += GravityVelocity() * Time.deltaTime;
        }
        else 
        {
            OnPlayerGrounded();
            if (!jumping) fallVelocity = 0.2f * Vector3.down;
        }

        characterController.Move(speed * Time.deltaTime * direction + fallVelocity * Time.deltaTime);
        Rotation();
    }

    void Rotation()
    {
        if (inputDirection.magnitude < 0.01f) return;
        float angle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (!groundDetector.triggered) return;
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpTime < Time.time - jumpStartTime) jumping = false;
            return;
        }
        jumpStartTime = Time.time;
        fallVelocity = jumpForce * Vector3.up;
        jumping = true;
    }

    Vector3 GravityVelocity()
    {
        return Vector3.down * gravity;
    }
}
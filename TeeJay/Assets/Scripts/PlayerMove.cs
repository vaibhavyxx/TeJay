using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float walkSpeed = 10f;
    [SerializeField] float jumpPower = 10f;
    Vector2 moveInput;
    Rigidbody myRigidbody;
    bool isGrounded = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.freezeRotation = true; // Prevent unwanted rotation
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate() // Use FixedUpdate for physics calculations
    {
        Run();
    }

    void Run()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
        Vector3 playerVelocity = moveDirection * walkSpeed;
        
        // Preserve Y velocity (gravity)
        myRigidbody.linearVelocity = new Vector3(playerVelocity.x, myRigidbody.linearVelocity.y, playerVelocity.z);
    }

    void Jump()
    {
        myRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision) // Corrected function name
    {
        if (collision.gameObject.CompareTag("Grounded")) // Make sure the ground has this tag
        {
            isGrounded = true;
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}

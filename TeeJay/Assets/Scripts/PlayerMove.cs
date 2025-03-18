using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Code is based on video https://www.youtube.com/watch?v=o1bj-49uQ74
//The code given didn't work that well, so used chatGPT to fix up the code.
public class PlayerMove : MonoBehaviour
{
    //Movement of the player body.
    [SerializeField] float walkSpeed = 15f;
    //How high we allow the player to jump
    [SerializeField] float jumpPower = 15f;
    Vector2 moveInput;
    Rigidbody myRigidbody;
    //A check to see if a player has landed on a platform with the tag "grounded"
    bool isGrounded = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.freezeRotation = true; // Prevent unwanted rotation
    }

    // Conditions for jumping, space bar to jump.
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            Jump();
        }
    }

    //Move the player x or y axis
    void FixedUpdate() // Use FixedUpdate for physics calculations
    {
        Run();
    }

    // Our movement of x and y axis.
    void Run()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
        Vector3 playerVelocity = moveDirection * walkSpeed;
        
        // Preserve Y velocity (gravity)
        myRigidbody.linearVelocity = new Vector3(playerVelocity.x, myRigidbody.linearVelocity.y, playerVelocity.z);
    }

    // Jump power for our player
    void Jump()
    {
        myRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        isGrounded = false;
    }

    // In order for the player to jump, the player must land on platform with the tage "Grounded". No infinite jumps.
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

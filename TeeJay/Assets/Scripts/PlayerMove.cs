using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
//Code is based on video https://www.youtube.com/watch?v=o1bj-49uQ74

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float walkSpeed = 15f;
    [SerializeField] float jumpPower = 15f;
    [SerializeField] Transform _cameraTransform;
    Vector2 moveInput;
    Rigidbody myRigidbody;
    bool isGrounded = false;        //to ensure player jumps only when 

    //gravity
    public float gravity = 100f;
    Time time = null;

    //KeyControl for current and prev
    KeyControl prevKB;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        //myRigidbody.freezeRotation = true; // Prevent unwanted rotation

        //Hides cursor, press ESC to show it again
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Conditions for jumping, space bar to jump.

    //Jump keypress is here to ensure that we are able to get information
    //from any frame when the user wants to jump
    void Update()
    {
        KeyControl currentKB = Keyboard.current.spaceKey;
        //Avoids infinite jump
        if (currentKB.wasPressedThisFrame
            && prevKB.isPressed
            && isGrounded)
        {
            Jump();
        }
        ApplyGravity();
        prevKB = currentKB;
    }

    //Move the player x or y axis
    void FixedUpdate() // Use FixedUpdate for physics calculations
    {
        Run();
    }

    void Run()
    {
        //Changed it from forceMode to ensure gravity still works when rigidbody moves
        Vector3 moveDirection = (_cameraTransform.right * moveInput.x + _cameraTransform.forward * moveInput.y);//transform.up.normalized;
        Vector3 newVelocity = new Vector3(
            moveDirection.x * walkSpeed,
            myRigidbody.linearVelocity.y, 
            moveDirection.z * walkSpeed);
        myRigidbody.linearVelocity = newVelocity;
    }

    // Jump power for our player
    void Jump()
    {
        myRigidbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        Debug.Log("Jump");
    }

    //When the player jumps, sets the grounded to false
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            isGrounded = false;
        }
    }

    // In order for the player to jump, the player must land on platform with the tage "Grounded". No infinite jumps.
    void OnCollisionStay(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Grounded")) 
        {
            isGrounded = true;
        }
    }
    
    //Get moveInput values from Input Action Reference
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if(moveInput.magnitude > 1)
        {
            moveInput.Normalize();
        }
    }

    //Ensures you fall properly
    void ApplyGravity()
    {
        if(!isGrounded)
        {
            myRigidbody.AddForce(Vector3.down * (Physics.gravity.y * gravity), ForceMode.Acceleration);
        }
    }
}

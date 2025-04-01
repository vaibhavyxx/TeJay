using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        //myRigidbody.freezeRotation = true; // Prevent unwanted rotation
    }
    // Conditions for jumping, space bar to jump.
    void Update()
    {
    }

    //Move the player x or y axis
    void FixedUpdate() // Use FixedUpdate for physics calculations
    {
        Run();
        ApplyGravity();

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            Jump();
        }
    }

    // Our movement of x and y axis.
    void Run()
    {
        //Changed it from forceMode to ensure gravity still works when rigidbody moves
        Vector3 moveDirection = (_cameraTransform.right * moveInput.x + _cameraTransform.forward * moveInput.y);//transform.up.normalized;
            //new Vector3(moveInput.x, 0f, moveInput.y).normalized;
        Vector3 newVelocity = new Vector3(
            moveDirection.x * walkSpeed,
            myRigidbody.linearVelocity.y, 
            moveDirection.z * walkSpeed);
        myRigidbody.linearVelocity = (newVelocity);
        Debug.Log("rb velocity: " + myRigidbody.linearVelocity);
    }

    // Jump power for our player
    void Jump()
    {
        myRigidbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        isGrounded = false;
    }

    // In order for the player to jump, the player must land on platform with the tage "Grounded". No infinite jumps.
    void OnCollisionStay(Collision collision) 
    {
        
        if (collision.gameObject.CompareTag("Grounded")) 
        {
            isGrounded = true;
        }
    }

    //shouldn't it be get context?
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.LogWarning("Move Input: " + moveInput);
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

    //Updates direction's axis
    private Vector3 newAxis()
    {
        return Vector3.zero;
    }
}

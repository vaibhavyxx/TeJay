using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    private Vector2 moveInputValue;

    // Read 2D joystick movement input
    private void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
        Debug.Log(moveInputValue);
    }

    // Optional button press actions
    private void OnButtonRegular()
    {
        Debug.Log("button pressed");
    }

    private void OnButtonHold()
    {
        Debug.Log("button held");
    }

    private void MoveLogicMethod()
    {
        // Move on X (left/right) and Z (forward/back)
        Vector3 move = new Vector3(moveInputValue.x, 0f, moveInputValue.y);
        rb.linearVelocity = move * speed;
    }

    private void FixedUpdate()
    {
        MoveLogicMethod();
    }
}


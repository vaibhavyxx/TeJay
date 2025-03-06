using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float movespeed = 0;
    Vector3 direction = Vector3.zero;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.AddForce(direction * movespeed,ForceMode.Force);
    }
    public void Move_Event(InputAction.CallbackContext context)
    {
            if(context.performed)
            {
                Vector2 input = context.ReadValue<Vector2>();
                direction.x = input.x;
                direction.z = input.y;
            }
            //Stop performing context
            else
            {
                direction = Vector3.zero;
            }
    }
}

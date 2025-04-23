using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Pool;

//Grab mechanic to work with the controller
//The idea is if the user is within a certain radius, and they have pressed b
//then the object would flag as grabbed
//then the object, transform would be the new transform

public class GrabController : MonoBehaviour
{
    public Transform grabObject;
    public Rigidbody grabRigidBody;
    public Transform grabTransform;
    bool isGrabbed = false;
    bool isTrigger = false;
    ButtonControl currentInput;
    ButtonControl dropInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentInput = Gamepad.current.bButton;     //takes in value from each b button - to grab item
        dropInput = Gamepad.current.yButton;        //to drop the item

        if (dropInput.isPressed)
        {
            grabRigidBody.useGravity = true;
            isGrabbed = false;
            isTrigger = false;
        }

        //if it is certain radius, the user should grab it - stays in the air
        if (isTrigger)
        {
            grabObject.transform.position = grabTransform.position;
            grabRigidBody.useGravity = false;
        }

        if(currentInput.isPressed)
        {
            isGrabbed=true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //only grabs if the item is within the radius and the button is pressed
        if (other.gameObject.CompareTag("Grab") && isGrabbed)
        {
            isTrigger = true;
        }
    }

  
}

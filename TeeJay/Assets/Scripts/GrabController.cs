using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

//Grab mechanic to work with the controller
//The idea is if the user is within a certain radius, and they have pressed b
//then the object would flag as grabbed
//then the object, transform would be the new transform
//Make sure that the gameobject this script is attached to, has a collider with trigger checked
public class GrabController : MonoBehaviour
{
    Transform grabObject;                       //grab object's coordinates
    Rigidbody grabRigidBody;                    //grab object's rigidbody to enable/disable gravity
    Rigidbody prevRigidBody;
    public Transform grabTransform;             //grabbed object is held at this coordinate

    //Boolean flags to ensure they work properly
    bool isGrabbed = false;
    bool isTrigger = false;

    //Plays haptics to let user know if they have grabbed something
    bool playsHaptics = false;
    float timer = 0.0f;

    //Takes in B and Y input for grab and drop
    ButtonControl currentInput;
    ButtonControl yInput;

    void Update()
    {
        //timer += Time.deltaTime;                 //for timing haptics
        currentInput = Gamepad.current.bButton;  //takes in value from each b button - to grab item
        yInput = Gamepad.current.yButton;        //to drop the item

        //If the user presses y, the object's rigidbody is using gravity and it is
        //detached from the player
        if (yInput.isPressed)
        {
            if (grabRigidBody != null)
            {
                grabRigidBody.useGravity = true;
            }

            isGrabbed = false;
            isTrigger = false;
            prevRigidBody = null;
            grabRigidBody = null;
        }

        //if it is certain radius, the user should grab it - stays in the air
        if (isTrigger)
        {
            grabObject.transform.position = grabTransform.position;
            grabRigidBody.useGravity = false;
        }

        //if B is pressed, then it turns on grab boolean
        if(currentInput.isPressed)
        {
            isGrabbed=true;
        }

        //for haptics
        if (prevRigidBody != grabRigidBody && grabRigidBody != null)
        {
            playsHaptics = true;
        }

        FeelTriggers(0.25f);
    }

    //Checks for multiple frames to ensure we can get information about the collider
    //whenever the object is pressed
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Grab") && isGrabbed)
        {
            //only grabs if the item is within the radius and the button is pressed
            //identifies the object's transform and rb
            prevRigidBody = grabRigidBody;
            grabObject = other.GetComponent<Transform>();
            grabRigidBody = other.GetComponent<Rigidbody>();
            isTrigger = true;
        }
    }

    //counts time and ensure the haptics are triggered for 0.25s
    void FeelTriggers(float playTime)
    {
        if (playsHaptics)
        {
            Gamepad.current.SetMotorSpeeds(0.25f, 0.25f);
            timer += Time.deltaTime;

            if(timer > playTime)
            {
                playsHaptics = false;
                InputSystem.PauseHaptics();
            }
        }
        else
        {
            timer = 0.0f;
        }
    }
  
}

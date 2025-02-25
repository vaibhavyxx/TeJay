using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Rotation : MonoBehaviour
{
    [SerializeField]private InputAction pressed, axis;
    private Transform cam; //The rotation only activates when playing the camera.
    [SerializeField]private float speed = 0.02f; //The speed of the rotation
    [SerializeField] private bool inverted; //Invert from opposite rotation direction
    private Vector2 rotation; //Rotate an object.
    private bool rotateAllowed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        cam = Camera.main.transform;
        pressed.Enable();
        axis.Enable();
        pressed.performed += _ => { StartCoroutine(Rotate());}; // Helps detect the rotation of mouse when it drag something.
        pressed.canceled += _ => { rotateAllowed = false;};
        axis.performed += context =>{rotation = context.ReadValue<Vector2>(); }; //Helps with the actual rotation withe mouse drag.

    }

    
    //Allows the user to drag an object and rotate to the direction where the mouse is going.
    private IEnumerator Rotate()
    {
        rotateAllowed = true;
        while(rotateAllowed)
        {
            rotation *=  speed; 
            Debug.Log(rotation);
            transform.Rotate(Vector3.up * (inverted? 1: -1), rotation.x, Space.World); // Helps get y-axis rotation correct
            transform.Rotate(cam.right * (inverted? -1: 1), rotation.y, Space.World); // Helps get x-axis roation correct
            yield return null;
        }
    }
}

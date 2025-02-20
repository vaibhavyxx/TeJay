using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
public class Rotation : MonoBehaviour
{
    [SerializeField]private InputAction pressed, axis;
    private Transform cam;
    [SerializeField]private float speed = 1;
    [SerializeField] private bool inverted;
    private Vector2 rotation;
    private bool rotateAllowed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        cam = Camera.main.transform;
        pressed.Enable();
        axis.Enable();
        pressed.performed += _ => { StartCoroutine(Rotate());};
        pressed.canceled += _ => { rotateAllowed = false;};
        axis.performed += context =>{rotation = context.ReadValue<Vector2>(); };

    }
    private IEnumerator Rotate()
    {
        rotateAllowed = true;
        while(rotateAllowed)
        {
            rotation *= speed;
            transform.Rotate(Vector3.up * (inverted? 1: -1), rotation.x, Space.World);
            transform.Rotate(cam.right * (inverted? -1: 1), rotation.y, Space.World);
            yield return null;
        }
    }
}

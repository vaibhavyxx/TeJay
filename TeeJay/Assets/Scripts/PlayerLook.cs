using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code is based from Youtube video https://www.youtube.com/watch?v=Tz-2Z0vLLt8
public class PlayerLook : MonoBehaviour
{
    //Our range of view
    [SerializeField] float minViewDistance = 25f;
    [SerializeField] Transform playerBody; 
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    //When you click on the play screen, the cursor goes away so it won't disturb your viewing, click 'esc' to get the cursor back.
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    // Now you rotate your view, look in all directions.
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, minViewDistance);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX); 
    }
}

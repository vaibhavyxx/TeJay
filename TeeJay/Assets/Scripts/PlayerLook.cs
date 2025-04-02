using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code is based from Youtube video https://www.youtube.com/watch?v=Tz-2Z0vLLt8
public class PlayerLook : MonoBehaviour
{
    //Our range of view
    [SerializeField] float minViewDistance = 25f;       //how down can you look
    [SerializeField] Transform playerBody; 
    public float mouseSensitivity = 100f;
    float mouseX, mouseY;
    float heightRotation = 0f;                          //to control how up and down can you look

    void Start()
    {
        //Hides cursor, press ESC to show it again
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    // Now you rotate your view, look in all directions.
    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        Debug.Log("Rotation Input: " + mouseX + ", " + mouseY);

        // Update camera rotation (pitch)
        heightRotation -= mouseY;
        heightRotation = Mathf.Clamp(heightRotation, -minViewDistance, minViewDistance); // Clamp for looking up/down
        transform.localRotation = Quaternion.Euler(heightRotation, 0f, 0f);

        // Rotate player body (yaw)
        //playerBody.Rotate(playerBody.transform.up * mouseX);
    }

    void onLook()
    {
    }
}
